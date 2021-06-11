// Decompiled with JetBrains decompiler
// Type: mindustry.ui.Fonts
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.assets.loaders.resolvers;
using arc.files;
using arc.freetype;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math.geom;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.core;
using mindustry.ctype;
using mindustry.gen;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.ui
{
  public class Fonts : Object
  {
    private const string mainFont = "fonts/font.woff";
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    private static ObjectSet unscaled;
    [Signature("Larc/struct/ObjectIntMap<Ljava/lang/String;>;")]
    private static ObjectIntMap unicodeIcons;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;")]
    private static ObjectMap stringIcons;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/graphics/g2d/TextureRegion;>;")]
    private static ObjectMap largeIcons;
    private static TextureRegion[] iconTable;
    private static int lastCid;
    public static Font def;
    public static Font outline;
    public static Font chat;
    public static Font icon;
    public static Font iconLarge;
    public static Font tech;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {11, 126, 126, 158, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadSystemCursors()
    {
      Graphics.Cursor.SystemCursor.__\u003C\u003Earrow.set(Core.graphics.newCursor("cursor", Fonts.cursorScale()));
      Graphics.Cursor.SystemCursor.__\u003C\u003Ehand.set(Core.graphics.newCursor("hand", Fonts.cursorScale()));
      Graphics.Cursor.SystemCursor.__\u003C\u003Eibeam.set(Core.graphics.newCursor("ibeam", Fonts.cursorScale()));
      Core.graphics.restoreCursor();
    }

    [LineNumberTable(new byte[] {111, 139, 127, 11, 102, 117, 246, 86, 230, 70, 159, 15, 255, 19, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadDefaultFont()
    {
      UI.packer = new PixmapPacker(Gl.getInt(3379) < 4096 ? 2048 : 4096, 2048, Pixmap.Format.__\u003C\u003Ergba8888, 2, true);
      InternalFileHandleResolver fileHandleResolver = new InternalFileHandleResolver();
      Core.assets.setLoader((Class) ClassLiteral<FreeTypeFontGenerator>.Value, (AssetLoader) new FreeTypeFontGeneratorLoader((FileHandleResolver) fileHandleResolver));
      Core.assets.setLoader((Class) ClassLiteral<Font>.Value, (string) null, (AssetLoader) new Fonts.\u0033((FileHandleResolver) fileHandleResolver));
      Fonts.\u0034 obj = new Fonts.\u0034();
      Core.assets.load("outline", (Class) ClassLiteral<Font>.Value, (AssetLoaderParameters) new FreetypeFontLoader.FreeTypeFontLoaderParameter("fonts/font.woff", (FreeTypeFontGenerator.FreeTypeFontParameter) obj)).loaded = (Cons) new Fonts.__\u003C\u003EAnon7();
      Core.assets.load("tech", (Class) ClassLiteral<Font>.Value, (AssetLoaderParameters) new FreetypeFontLoader.FreeTypeFontLoaderParameter("fonts/tech.ttf", (FreeTypeFontGenerator.FreeTypeFontParameter) new Fonts.\u0035())).loaded = (Cons) new Fonts.__\u003C\u003EAnon8();
    }

    [LineNumberTable(new byte[] {160, 95, 145, 149, 119, 159, 0, 103, 159, 37, 159, 1, 159, 24, 115, 165, 109, 102, 135, 103, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void mergeFontAtlas(TextureAtlas atlas)
    {
      Texture texture = atlas.find("logo").texture;
      PixmapPacker.Page page = (PixmapPacker.Page) UI.packer.getPages().first();
      Iterator iterator = atlas.getRegions().select((Boolf) new Fonts.__\u003C\u003EAnon9(texture)).iterator();
      while (iterator.hasNext())
      {
        TextureAtlas.AtlasRegion region = (TextureAtlas.AtlasRegion) iterator.next();
        page.setDirty(false);
        Rect rect = UI.packer.pack(new StringBuilder().append(region.name).append(region.splits == null ? "" : ".9").toString(), atlas.getPixmap(region));
        region.texture = ((PixmapPacker.Page) UI.packer.getPages().first()).getTexture();
        region.set(ByteCodeHelper.f2i(rect.x), ByteCodeHelper.f2i(rect.y), ByteCodeHelper.f2i(rect.width), ByteCodeHelper.f2i(rect.height));
        atlas.getTextures().add((object) region.texture);
      }
      atlas.getTextures().remove((object) texture);
      texture.dispose();
      atlas.disposePixmap(texture);
      page.setDirty(true);
      page.updateTexture(Texture.TextureFilter.__\u003C\u003Elinear, Texture.TextureFilter.__\u003C\u003Elinear, false);
    }

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string getUnicodeStr(string content) => (string) Fonts.stringIcons.get((object) content, (object) "");

    [LineNumberTable(new byte[] {159, 83, 66, 109, 159, 35, 115, 255, 17, 93, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegionDrawable getGlyph(Font font, char glyph)
    {
      int num1 = (int) glyph;
      Font.Glyph glyph1 = font.getData().getGlyph((char) num1);
      if (glyph1 == null)
      {
        string str = new StringBuilder().append("No glyph: ").append((char) num1).append(" (").append(num1).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      float num2 = (float) Math.max(glyph1.width, glyph1.height);
      Fonts.\u0036 obj = new Fonts.\u0036(new TextureRegion(font.getRegion().texture, glyph1.u, glyph1.v2, glyph1.u2, glyph1.v), glyph1, num2);
      obj.setMinWidth(num2);
      obj.setMinHeight(num2);
      return (TextureRegionDrawable) obj;
    }

    [LineNumberTable(new byte[] {23, 106, 134, 127, 15, 127, 15, 255, 19, 69, 255, 19, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadFonts()
    {
      Fonts.largeIcons.clear();
      FreeTypeFontGenerator.FreeTypeFontParameter fontParameters = Fonts.fontParameter();
      Core.assets.load("default", (Class) ClassLiteral<Font>.Value, (AssetLoaderParameters) new FreetypeFontLoader.FreeTypeFontLoaderParameter("fonts/font.woff", fontParameters)).loaded = (Cons) new Fonts.__\u003C\u003EAnon0();
      Core.assets.load("chat", (Class) ClassLiteral<Font>.Value, (AssetLoaderParameters) new FreetypeFontLoader.FreeTypeFontLoaderParameter("fonts/font.woff", fontParameters)).loaded = (Cons) new Fonts.__\u003C\u003EAnon1();
      Core.assets.load("icon", (Class) ClassLiteral<Font>.Value, (AssetLoaderParameters) new FreetypeFontLoader.FreeTypeFontLoaderParameter("fonts/icon.ttf", (FreeTypeFontGenerator.FreeTypeFontParameter) new Fonts.\u0031())).loaded = (Cons) new Fonts.__\u003C\u003EAnon2();
      Core.assets.load("iconLarge", (Class) ClassLiteral<Font>.Value, (AssetLoaderParameters) new FreetypeFontLoader.FreeTypeFontLoaderParameter("fonts/icon.ttf", (FreeTypeFontGenerator.FreeTypeFontParameter) new Fonts.\u0032())).loaded = (Cons) new Fonts.__\u003C\u003EAnon3();
    }

    [LineNumberTable(new byte[] {55, 127, 5, 117, 159, 7, 127, 5, 107, 104, 110, 112, 108, 105, 142, 111, 165, 112, 159, 12, 103, 105, 104, 104, 104, 127, 3, 110, 110, 110, 110, 104, 105, 104, 104, 104, 104, 116, 119, 232, 30, 255, 18, 100, 111, 118, 134, 244, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void loadContentIcons()
    {
      Seq seq = Seq.with((object[]) new Font[3]
      {
        Fonts.chat,
        Fonts.def,
        Fonts.outline
      });
      Texture texture = Core.atlas.find("logo").texture;
      int num1 = ByteCodeHelper.f2i(Fonts.def.getData().lineHeight / Fonts.def.getData().scaleY);
      Scanner.__\u003Cclinit\u003E();
      Scanner scanner = new Scanner((InputStream) Core.files.@internal("icons/icons.properties").read(512));
      Exception exception1;
      try
      {
        while (scanner.hasNextLine())
        {
          string[] strArray1 = String.instancehelper_split(scanner.nextLine(), "=");
          string[] strArray2 = String.instancehelper_split(strArray1[1], "\\|");
          string str = strArray1[0];
          string name = strArray2[1];
          int num2 = Integer.parseInt(str);
          TextureAtlas.AtlasRegion atlasRegion = Core.atlas.find(name);
          if (object.ReferenceEquals((object) atlasRegion.texture, (object) texture))
          {
            Fonts.unicodeIcons.put((object) strArray2[0], num2);
            Fonts.stringIcons.put((object) strArray2[0], (object) new StringBuilder().append((char) num2).append("").toString());
            seq.each((Cons) new Fonts.__\u003C\u003EAnon5(num2, new Font.Glyph()
            {
              id = num2,
              srcX = 0,
              srcY = 0,
              width = num1,
              height = ByteCodeHelper.f2i((float) atlasRegion.height / (float) atlasRegion.width * (float) num1),
              u = atlasRegion.u,
              v = atlasRegion.v2,
              u2 = atlasRegion.u2,
              v2 = atlasRegion.v,
              xoffset = 0,
              yoffset = -num1,
              xadvance = num1,
              kerning = (byte[][]) null,
              fixedWidth = true,
              page = 0
            }));
          }
        }
        goto label_6;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Exception exception3;
      try
      {
        scanner.close();
        goto label_10;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      Throwable.instancehelper_addSuppressed(exception2, exception4);
label_10:
      throw Throwable.__\u003Cunmap\u003E(exception2);
label_6:
      scanner.close();
      Fonts.iconTable = new TextureRegion[512];
      Fonts.iconTable[0] = (TextureRegion) Core.atlas.find("error");
      Fonts.lastCid = 1;
      Vars.content.each((Cons) new Fonts.__\u003C\u003EAnon6());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int cursorScale() => 1;

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion getLargeIcon(string name) => (TextureRegion) Fonts.largeIcons.get((object) name, (Prov) new Fonts.__\u003C\u003EAnon4(name));

    [LineNumberTable(275)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static FreeTypeFontGenerator.FreeTypeFontParameter fontParameter() => (FreeTypeFontGenerator.FreeTypeFontParameter) new Fonts.\u0037();

    [Modifiers]
    [LineNumberTable(76)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadFonts\u00240([In] object obj0) => Fonts.def = (Font) obj0;

    [Modifiers]
    [LineNumberTable(77)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadFonts\u00241([In] object obj0) => Fonts.chat = (Font) obj0;

    [Modifiers]
    [LineNumberTable(82)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadFonts\u00242([In] object obj0) => Fonts.icon = (Font) obj0;

    [Modifiers]
    [LineNumberTable(89)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadFonts\u00243([In] object obj0) => Fonts.iconLarge = (Font) obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {44, 102, 113, 114, 115, 117, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static TextureRegion lambda\u0024getLargeIcon\u00244([In] string obj0)
    {
      TextureRegion textureRegion = new TextureRegion();
      int num = Iconc.__\u003C\u003Ecodes.get((object) obj0, 63700);
      Font.Glyph glyph = Fonts.iconLarge.getData().getGlyph((char) num);
      if (glyph == null)
        return (TextureRegion) Core.atlas.find("error");
      textureRegion.set(Fonts.iconLarge.getRegion().texture);
      textureRegion.set(glyph.u, glyph.v2, glyph.u2, glyph.v);
      return textureRegion;
    }

    [Modifiers]
    [LineNumberTable(141)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadContentIcons\u00245([In] int obj0, [In] Font.Glyph obj1, [In] Font obj2) => obj2.getData().setGlyph(obj0, obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {100, 127, 3, 127, 11, 104, 191, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadContentIcons\u00246([In] Content obj0)
    {
      Content content = obj0;
      UnlockableContent unlockableContent1;
      if (!(content is UnlockableContent) || !object.ReferenceEquals((object) (unlockableContent1 = (UnlockableContent) content), (object) (UnlockableContent) content))
        return;
      TextureAtlas.AtlasRegion atlasRegion1 = Core.atlas.find(new StringBuilder().append(unlockableContent1.__\u003C\u003Ename).append("-icon-logic").toString());
      if (!atlasRegion1.found())
        return;
      TextureRegion[] iconTable = Fonts.iconTable;
      UnlockableContent unlockableContent2 = unlockableContent1;
      int num = Fonts.lastCid++;
      UnlockableContent unlockableContent3 = unlockableContent2;
      int index = num;
      unlockableContent3.iconId = num;
      TextureAtlas.AtlasRegion atlasRegion2 = atlasRegion1;
      iconTable[index] = (TextureRegion) atlasRegion2;
    }

    [Modifiers]
    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadDefaultFont\u00247([In] object obj0) => Fonts.outline = (Font) obj0;

    [Modifiers]
    [LineNumberTable(new byte[] {160, 85, 107, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadDefaultFont\u00248([In] object obj0)
    {
      Fonts.tech = (Font) obj0;
      ((Font) obj0).getData().down *= 1.5f;
    }

    [Modifiers]
    [LineNumberTable(213)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024mergeFontAtlas\u00249(
      [In] Texture obj0,
      [In] TextureAtlas.AtlasRegion obj1)
    {
      return object.ReferenceEquals((object) obj1.texture, (object) obj0);
    }

    [LineNumberTable(31)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fonts()
    {
    }

    [LineNumberTable(48)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static TextureRegion logicIcon(int id) => Fonts.iconTable[id];

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int getUnicode(string content) => Fonts.unicodeIcons.get((object) content, 0);

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static ObjectSet access\u0024000() => Fonts.unscaled;

    [LineNumberTable(new byte[] {159, 134, 109, 120, 106, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Fonts()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.ui.Fonts"))
        return;
      Fonts.unscaled = ObjectSet.with((object[]) new string[1]
      {
        nameof (iconLarge)
      });
      Fonts.unicodeIcons = new ObjectIntMap();
      Fonts.stringIcons = new ObjectMap();
      Fonts.largeIcons = new ObjectMap();
    }

    [InnerClass]
    [EnclosingMethod(null, "loadFonts", "()V")]
    [SpecialName]
    internal class \u0031 : FreeTypeFontGenerator.FreeTypeFontParameter
    {
      [LineNumberTable(new byte[] {28, 104, 104, 103, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031()
      {
        Fonts.\u0031 obj = this;
        this.size = 30;
        this.incremental = true;
        this.characters = "\0";
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "loadFonts", "()V")]
    [SpecialName]
    internal class \u0032 : FreeTypeFontGenerator.FreeTypeFontParameter
    {
      [LineNumberTable(new byte[] {33, 104, 104, 103, 107, 107, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032()
      {
        Fonts.\u0032 obj = this;
        this.size = 48;
        this.incremental = false;
        this.characters = "\0\uF15C\uF15B\uF0F6\uE802\uE803\uE804\uE805\uE807\uE800\uE808\uE809\uE80B\uE80F\uF300\uF1C5\uE813\uE816\uE819\uE81A\uF0B0\uE81D\uE822\uE824\uE825\uE826\uE827\uE823\uE829\uE806\uE811\uE815\uE818\uF120\uE835\uE836\uF129\uE837\uE839\uE83A\uE83B\uE83E\uE83F\uF12D\uE801\uF029\uE812\uE842\uE844\uE80D\uE81E\uF281\uF308\uE83D\uE845\uF181\uE80E\uE814\uE817\uE81B\uE81C\uE82A\uE82B\uE82C\uE82D\uE830\uE84C\uE852\uE853\uE85B\uE85C\uE85D\uE85E\uE85F\uE861\uE865\uE867\uE868\uE869\uE86A\uE86B\uE86C\uE86D\uE86E\uE86F\uE870\uE871\uE872\uE873\uE874\uE875\uE876\uE877\uE878\uE879\uE87B\uE87C\uE87D\uE88A\uE88B\uE810\uE88C\uE88D\uE88E\uE88F⚠\uE864\uE84D";
        this.borderWidth = 5f;
        this.borderColor = Color.__\u003C\u003EdarkGray;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "loadDefaultFont", "()V")]
    [SpecialName]
    internal class \u0033 : FreetypeFontLoader
    {
      [Signature("Larc/struct/ObjectSet<Larc/freetype/FreeTypeFontGenerator$FreeTypeFontParameter;>;")]
      internal ObjectSet scaled;

      [LineNumberTable(new byte[] {116, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0033([In] FileHandleResolver obj0)
        : base(obj0)
      {
        Fonts.\u0033 obj = this;
        this.scaled = new ObjectSet();
      }

      [LineNumberTable(new byte[] {121, 109, 119, 191, 7, 127, 2, 127, 5, 179, 113, 113, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Font loadSync(
        [In] AssetManager obj0,
        [In] string obj1,
        [In] Fi obj2,
        [In] FreetypeFontLoader.FreeTypeFontLoaderParameter obj3)
      {
        if (String.instancehelper_equals(obj1, (object) "outline"))
        {
          obj3.fontParameters.borderWidth = Scl.scl(2f);
          FreeTypeFontGenerator.FreeTypeFontParameter fontParameters = obj3.fontParameters;
          fontParameters.spaceX = ByteCodeHelper.f2i((float) fontParameters.spaceX - obj3.fontParameters.borderWidth);
        }
        if (!this.scaled.contains((object) obj3.fontParameters) && !Fonts.access\u0024000().contains((object) obj1))
        {
          obj3.fontParameters.size = ByteCodeHelper.f2i(Scl.scl((float) obj3.fontParameters.size));
          this.scaled.add((object) obj3.fontParameters);
        }
        obj3.fontParameters.magFilter = Texture.TextureFilter.__\u003C\u003Elinear;
        obj3.fontParameters.minFilter = Texture.TextureFilter.__\u003C\u003Elinear;
        obj3.fontParameters.packer = UI.packer;
        return base.loadSync(obj0, obj1, obj2, obj3);
      }

      [Modifiers]
      [LineNumberTable(166)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object loadSync(
        [In] AssetManager obj0,
        [In] string obj1,
        [In] Fi obj2,
        [In] AssetLoaderParameters obj3)
      {
        return (object) this.loadSync(obj0, obj1, obj2, (FreetypeFontLoader.FreeTypeFontLoaderParameter) obj3);
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "loadDefaultFont", "()V")]
    [SpecialName]
    internal class \u0034 : FreeTypeFontGenerator.FreeTypeFontParameter
    {
      [LineNumberTable(new byte[] {160, 74, 104, 107, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0034()
      {
        Fonts.\u0034 obj = this;
        this.borderColor = Color.__\u003C\u003EdarkGray;
        this.incremental = true;
        this.size = 18;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "loadDefaultFont", "()V")]
    [SpecialName]
    internal class \u0035 : FreeTypeFontGenerator.FreeTypeFontParameter
    {
      [LineNumberTable(new byte[] {160, 82, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0035()
      {
        Fonts.\u0035 obj = this;
        this.size = 18;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, "getGlyph", "(Larc.graphics.g2d.Font;C)Larc.scene.style.TextureRegionDrawable;")]
    [SpecialName]
    internal class \u0036 : TextureRegionDrawable
    {
      [Modifiers]
      internal Font.Glyph val\u0024g;
      [Modifiers]
      internal float val\u0024size;

      [LineNumberTable(240)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0036([In] TextureRegion obj0, [In] Font.Glyph obj1, [In] float obj2)
      {
        this.val\u0024g = obj1;
        this.val\u0024size = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj0);
      }

      [LineNumberTable(new byte[] {160, 129, 127, 6, 127, 40, 104, 104, 127, 48})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw([In] float obj0, [In] float obj1, [In] float obj2, [In] float obj3)
      {
        Draw.color(Tmp.__\u003C\u003Ec1.set(this.tint).mul(Draw.getColor()).toFloatBits());
        float num1 = obj0 + obj2 / 2f - (float) this.val\u0024g.width / 2f;
        float num2 = obj1 + obj3 / 2f - (float) this.val\u0024g.height / 2f;
        Draw.rect(this.region, (float) ByteCodeHelper.f2i(num1) + (float) this.val\u0024g.width / 2f, (float) ByteCodeHelper.f2i(num2) + (float) this.val\u0024g.height / 2f, (float) this.val\u0024g.width, (float) this.val\u0024g.height);
      }

      [LineNumberTable(new byte[] {160, 138, 106, 106, 127, 6, 127, 41, 104, 104, 116, 116, 127, 53})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw(
        [In] float obj0,
        [In] float obj1,
        [In] float obj2,
        [In] float obj3,
        [In] float obj4,
        [In] float obj5,
        [In] float obj6,
        [In] float obj7,
        [In] float obj8)
      {
        obj4 *= obj6;
        obj5 *= obj7;
        Draw.color(Tmp.__\u003C\u003Ec1.set(this.tint).mul(Draw.getColor()).toFloatBits());
        float num1 = obj0 + obj4 / 2f - (float) this.val\u0024g.width / 2f;
        float num2 = obj1 + obj5 / 2f - (float) this.val\u0024g.height / 2f;
        Draw.rect(this.region, (float) ByteCodeHelper.f2i(num1) + (float) this.val\u0024g.width / 2f, (float) ByteCodeHelper.f2i(num2) + (float) this.val\u0024g.height / 2f, (float) this.val\u0024g.width, (float) this.val\u0024g.height, (float) this.val\u0024g.width / 2f, (float) this.val\u0024g.height / 2f, obj8);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override float imageSize() => this.val\u0024size;
    }

    [InnerClass]
    [EnclosingMethod(null, "fontParameter", "()Larc.freetype.FreeTypeFontGenerator$FreeTypeFontParameter;")]
    [SpecialName]
    internal class \u0037 : FreeTypeFontGenerator.FreeTypeFontParameter
    {
      [LineNumberTable(new byte[] {160, 161, 104, 104, 107, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0037()
      {
        Fonts.\u0037 obj = this;
        this.size = 18;
        this.shadowColor = Color.__\u003C\u003EdarkGray;
        this.shadowOffsetY = 2;
        this.incremental = true;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadFonts\u00240(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadFonts\u00241(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadFonts\u00242(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadFonts\u00243(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Prov
    {
      private readonly string arg\u00241;

      internal __\u003C\u003EAnon4([In] string obj0) => this.arg\u00241 = obj0;

      public object get() => (object) Fonts.lambda\u0024getLargeIcon\u00244(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Cons
    {
      private readonly int arg\u00241;
      private readonly Font.Glyph arg\u00242;

      internal __\u003C\u003EAnon5([In] int obj0, [In] Font.Glyph obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadContentIcons\u00245(this.arg\u00241, this.arg\u00242, (Font) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Cons
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadContentIcons\u00246((Content) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadDefaultFont\u00247(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Cons
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public void get([In] object obj0) => Fonts.lambda\u0024loadDefaultFont\u00248(obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolf
    {
      private readonly Texture arg\u00241;

      internal __\u003C\u003EAnon9([In] Texture obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (Fonts.lambda\u0024mergeFontAtlas\u00249(this.arg\u00241, (TextureAtlas.AtlasRegion) obj0) ? 1 : 0) != 0;
    }
  }
}
