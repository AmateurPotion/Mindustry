// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.LoadRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.func;
using arc.fx;
using arc.fx.filters;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.g3d;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.scene.ui.layout;
using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using mindustry.graphics.g3d;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class LoadRenderer : Object, Disposable
  {
    [Modifiers]
    private static Color color;
    [Modifiers]
    private static Color colorRed;
    [Modifiers]
    private static string red;
    [Modifiers]
    private static string orange;
    [Modifiers]
    private static FloatSeq floats;
    private const bool preview = false;
    private float testprogress;
    private StringBuilder assetText;
    private LoadRenderer.Bar[] bars;
    private Mesh mesh;
    private Camera3D cam;
    private int lastLength;
    private FxProcessor fx;
    private WindowedMean renderTimes;
    private long lastFrameTime;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 166, 232, 72, 107, 139, 119, 107, 135, 237, 70, 191, 10, 2, 97, 244, 69, 144, 191, 61, 191, 160, 74, 223, 160, 105, 159, 46})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public LoadRenderer()
    {
      LoadRenderer loadRenderer = this;
      this.testprogress = 0.0f;
      this.assetText = new StringBuilder();
      this.mesh = MeshBuilder.buildHex(LoadRenderer.colorRed, 2, true, 1f);
      this.cam = new Camera3D();
      this.lastLength = -1;
      this.renderTimes = new WindowedMean(20);
      try
      {
        this.fx = new FxProcessor(Pixmap.Format.__\u003C\u003Ergba8888, 2, 2, false, true);
        goto label_5;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      this.fx = new FxProcessor(Pixmap.Format.__\u003C\u003Ergb565, 2, 2, false, true);
label_5:
      this.fx.addEffect((FxFilter) new BloomFilter());
      this.bars = new LoadRenderer.Bar[10]
      {
        new LoadRenderer.Bar("s_proc#", (float) OS.__\u003C\u003Ecores / 16f, OS.__\u003C\u003Ecores < 4),
        new LoadRenderer.Bar("c_aprog", (Boolp) new LoadRenderer.__\u003C\u003EAnon0(), (Floatp) new LoadRenderer.__\u003C\u003EAnon1(), (Boolp) new LoadRenderer.__\u003C\u003EAnon2()),
        new LoadRenderer.Bar("g_vtype", !object.ReferenceEquals((object) Core.graphics.getGLVersion().__\u003C\u003Etype, (object) GLVersion.GlType.__\u003C\u003EGLES) ? 1f : 0.5f, object.ReferenceEquals((object) Core.graphics.getGLVersion().__\u003C\u003Etype, (object) GLVersion.GlType.__\u003C\u003EGLES)),
        new LoadRenderer.Bar("s_mem#", (Boolp) new LoadRenderer.__\u003C\u003EAnon3(), (Floatp) new LoadRenderer.__\u003C\u003EAnon4(), (Boolp) new LoadRenderer.__\u003C\u003EAnon5()),
        new LoadRenderer.Bar("v_ver#", (Boolp) new LoadRenderer.__\u003C\u003EAnon6(), (Floatp) new LoadRenderer.__\u003C\u003EAnon7(), (Boolp) new LoadRenderer.__\u003C\u003EAnon8()),
        new LoadRenderer.Bar("s_osv", !OS.isWindows ? (!OS.isLinux ? (!OS.isMac ? 0.2f : 0.5f) : 0.9f) : 0.35f, OS.isMac),
        new LoadRenderer.Bar("v_worlds#", (Boolp) new LoadRenderer.__\u003C\u003EAnon9(), (Floatp) new LoadRenderer.__\u003C\u003EAnon10(), (Boolp) new LoadRenderer.__\u003C\u003EAnon11()),
        new LoadRenderer.Bar("c_datas#", (Boolp) new LoadRenderer.__\u003C\u003EAnon12(), (Floatp) new LoadRenderer.__\u003C\u003EAnon13(), (Boolp) new LoadRenderer.__\u003C\u003EAnon14()),
        new LoadRenderer.Bar("v_alterc", (Boolp) new LoadRenderer.__\u003C\u003EAnon15(), (Floatp) new LoadRenderer.__\u003C\u003EAnon16(), (Boolp) new LoadRenderer.__\u003C\u003EAnon17()),
        new LoadRenderer.Bar("g_vcomp#", ((float) Core.graphics.getGLVersion().majorVersion + (float) Core.graphics.getGLVersion().minorVersion / 10f) / 4.6f, !Core.graphics.getGLVersion().atLeast(3, 2))
      };
    }

    [LineNumberTable(new byte[] {26, 106, 171, 116, 108, 171, 127, 15, 191, 0, 140, 117, 108, 127, 8, 127, 87, 102, 127, 1, 127, 94, 122, 133, 176, 143, 191, 2, 159, 12, 100, 114, 171, 159, 25, 107, 109, 112, 241, 77, 148, 135, 110, 107, 159, 8, 243, 61, 40, 235, 72, 133, 135, 159, 29, 191, 79, 118, 108, 108, 166, 100, 133, 109, 187, 107, 127, 13, 104, 107, 139, 106, 135, 121, 153, 116, 118, 141, 131, 127, 0, 127, 0, 159, 12, 138, 104, 125, 127, 8, 127, 8, 159, 22, 127, 0, 157, 112, 165, 125, 125, 127, 39, 191, 39, 124, 116, 127, 1, 108, 140, 108, 236, 58, 235, 73, 101, 106, 133, 138, 133, 103, 135, 103, 127, 0, 127, 52, 104, 104, 139, 159, 11, 109, 139, 108, 107, 108, 122, 117, 112, 127, 27, 152, 159, 9, 255, 18, 71, 138, 255, 22, 70, 108, 127, 1, 255, 50, 36, 235, 96, 106, 141, 107, 107, 107, 115, 145, 108, 121, 112, 159, 24, 119, 103, 116, 124, 105, 102, 150, 135, 255, 11, 58, 232, 55, 235, 82, 138, 109, 133, 127, 43, 107, 108, 111, 159, 49, 175, 143, 103, 187, 117, 146, 112, 147, 127, 1, 113, 122, 112, 107, 106, 127, 0, 177, 173, 99, 105, 120, 31, 14, 232, 69, 106, 159, 14, 108, 159, 39, 138, 146, 177, 107, 118, 111, 171, 159, 0, 127, 0, 158, 108, 127, 5, 29, 235, 59, 235, 79, 130, 117, 245, 70, 118, 111, 108, 108, 159, 29, 127, 31, 119, 106, 254, 58, 43, 235, 74, 170, 167, 133, 139, 230, 159, 30, 43, 235, 160, 234, 101, 123, 127, 6, 108, 205, 107, 107, 117, 108, 135, 106, 125, 103, 106, 159, 20, 108, 105, 117, 127, 4, 145, 127, 0, 107, 139, 126, 127, 35, 255, 14, 58, 235, 58, 235, 82, 117, 127, 4, 113, 191, 5, 116, 159, 10, 127, 126, 159, 113, 118, 108, 106, 191, 160, 91, 133, 140, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw()
    {
      if (this.lastFrameTime == 0L)
        this.lastFrameTime = Time.millis();
      this.renderTimes.add((float) Time.timeSinceMillis(this.lastFrameTime) / 1000f);
      this.lastFrameTime = Time.millis();
      if (this.fx.getWidth() != Core.graphics.getWidth() || this.fx.getHeight() != Core.graphics.getHeight())
        this.fx.resize(Core.graphics.getWidth(), Core.graphics.getHeight());
      this.fx.begin();
      CharSequence charSequence1;
      if (Core.assets.getLoadedAssets() != this.lastLength)
      {
        this.assetText.setLength(0);
        Iterator iterator = Core.assets.getAssetNames().iterator();
        while (iterator.hasNext())
        {
          string fileName = (string) iterator.next();
          string lowerCase1 = String.instancehelper_toLowerCase(fileName);
          object obj1 = (object) "mod";
          charSequence1.__\u003Cref\u003E = (__Null) obj1;
          CharSequence charSequence2 = charSequence1;
          int num;
          if (!String.instancehelper_contains(lowerCase1, charSequence2))
          {
            string lowerCase2 = String.instancehelper_toLowerCase(Core.assets.getAssetType(fileName).getSimpleName());
            object obj2 = (object) "mod";
            charSequence1.__\u003Cref\u003E = (__Null) obj2;
            CharSequence charSequence3 = charSequence1;
            if (!String.instancehelper_contains(lowerCase2, charSequence3))
            {
              string str = fileName;
              object obj3 = (object) "preview";
              charSequence1.__\u003Cref\u003E = (__Null) obj3;
              CharSequence charSequence4 = charSequence1;
              if (!String.instancehelper_contains(str, charSequence4))
              {
                num = 0;
                goto label_12;
              }
            }
          }
          num = 1;
label_12:
          StringBuilder stringBuilder = this.assetText.append(num == 0 ? LoadRenderer.orange : LoadRenderer.red);
          string str1 = fileName;
          string username = OS.__\u003C\u003Eusername;
          object obj4 = (object) "<<host>>";
          object obj5 = (object) username;
          charSequence1.__\u003Cref\u003E = (__Null) obj5;
          CharSequence charSequence5 = charSequence1;
          object obj6 = obj4;
          charSequence1.__\u003Cref\u003E = (__Null) obj6;
          CharSequence charSequence6 = charSequence1;
          string str2 = String.instancehelper_replace(str1, charSequence5, charSequence6);
          object obj7 = (object) "::";
          object obj8 = (object) "/";
          charSequence1.__\u003Cref\u003E = (__Null) obj8;
          CharSequence charSequence7 = charSequence1;
          object obj9 = obj7;
          charSequence1.__\u003Cref\u003E = (__Null) obj9;
          CharSequence charSequence8 = charSequence1;
          string str3 = String.instancehelper_replace(str2, charSequence7, charSequence8);
          stringBuilder.append(str3).append(LoadRenderer.red).append("::[]").append(Core.assets.getAssetType(fileName).getSimpleName()).append("\n");
        }
        this.lastLength = Core.assets.getLoadedAssets();
      }
      Core.graphics.clear(Color.__\u003C\u003Eblack);
      float width1 = (float) Core.graphics.getWidth();
      float height1 = (float) Core.graphics.getHeight();
      float num1 = Scl.scl();
      Draw.proj().setOrtho(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      int sides = 20;
      float radius1 = Math.max(width1, height1) * 0.6f;
      float thick = 5f * num1;
      Fill.light(width1 / 2f, height1 / 2f, sides, radius1, Tmp.__\u003C\u003Ec1.set(LoadRenderer.color).a(0.15f), Color.__\u003C\u003Eclear);
      float num2 = num1 * 60f;
      float progress = Core.assets.getProgress();
      int num3 = ByteCodeHelper.f2i(width1 / num2) / 2 + 1;
      int num4 = ByteCodeHelper.f2i(height1 / num2) / 2 + 1;
      Draw.color(Pal.accent, Color.__\u003C\u003Eblack, 0.9f);
      Lines.stroke(thick);
      for (int index1 = -num3; index1 <= num3; ++index1)
      {
        for (int index2 = -num4; index2 <= num4; ++index2)
          Lines.poly((float) index1 * num2 + width1 / 2f, (float) index2 * num2 + height1 / 2f, 4, num2 / 2f);
      }
      Draw.flush();
      float num5 = 1.94f;
      Vec2 vec2 = Scaling.__\u003C\u003Efit.apply((float) Core.graphics.getWidth(), (float) Core.graphics.getWidth() / num5, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      int width2 = ByteCodeHelper.f2i(vec2.x);
      int height2 = ByteCodeHelper.f2i(vec2.y);
      int x1 = ByteCodeHelper.f2i((float) Core.graphics.getWidth() / 2f - vec2.x / 2f);
      int y1 = ByteCodeHelper.f2i((float) Core.graphics.getHeight() / 2f - vec2.y / 2f);
      if (Core.graphics.getHeight() > Core.graphics.getWidth())
      {
        height2 = Core.graphics.getHeight();
        width2 = Core.graphics.getWidth();
        x1 = y1 = 0;
      }
      float num6 = (float) width2;
      float num7 = (float) height2;
      Gl.viewport(x1, y1, width2, height2);
      Draw.proj().setOrtho(0.0f, 0.0f, (float) width2, (float) height2);
      float num8 = 110f * num1;
      float radius2 = Math.min(Math.min(num6, num7) / 3.1f, Math.min(num6, num7) / 2f - num8);
      float radius3 = radius2 + num8;
      float num9 = 60f * num1;
      float num10 = 100f * num1;
      Draw.color(LoadRenderer.color);
      Lines.stroke(thick);
      Lines.poly(num6 / 2f, num7 / 2f, 4, radius2);
      Lines.poly(num6 / 2f, num7 / 2f, 4, radius3);
      if (Core.assets.isLoaded("tech"))
      {
        Font font1 = (Font) Core.assets.get("tech");
        font1.getData().markupEnabled = true;
        int num11 = 0;
        int[] signs1 = Mathf.__\u003C\u003Esigns;
        int length1 = signs1.Length;
        for (int index1 = 0; index1 < length1; ++index1)
        {
          int num12 = signs1[index1];
          int[] signs2 = Mathf.__\u003C\u003Esigns;
          int length2 = signs2.Length;
          for (int index2 = 0; index2 < length2; ++index2)
          {
            int num13 = signs2[index2];
            float num14 = num7 / 2f + (float) num13 * radius3;
            float num15 = num7 / 2f + (float) num13 * 120f;
            LoadRenderer.floats.clear();
            if ((double) num6 > (double) num7)
            {
              LoadRenderer.floats.add(num6 / 2f + (float) num12 * num10, num14);
              LoadRenderer.floats.add(num6 / 2f + (num6 / 2f - num9) * (float) num12, num14);
              LoadRenderer.floats.add(num6 / 2f + (num6 / 2f - num9) * (float) num12, num15);
              LoadRenderer.floats.add(num6 / 2f + (float) num12 * num10 + (float) num12 * Math.abs(num15 - num14), num15);
            }
            else
            {
              float num16 = num7 / 2f + (num7 / 2f - num9) * (float) num13;
              float num17 = num13 >= 0 ? Math.max(num15, num14) : Math.min(num15, num14);
              if ((double) (num16 * (float) num13) >= (double) (num17 * (float) num13))
              {
                LoadRenderer.floats.add(num6 / 2f + (float) num12 * num10, num14);
                LoadRenderer.floats.add(num6 / 2f + (float) num12 * num10, num16);
                LoadRenderer.floats.add(Mathf.clamp(num6 / 2f + (float) num12 * (num10 + Math.abs(num15 - num14)), thick / 2f, num6 - thick / 2f), num16);
                LoadRenderer.floats.add(Mathf.clamp(num6 / 2f + (float) num12 * (num10 + Math.abs(num15 - num14)), thick / 2f, num6 - thick / 2f), num15);
              }
              else
                continue;
            }
            float num18 = float.MaxValue;
            float num19 = float.MaxValue;
            float num20 = 0.0f;
            float num21 = 0.0f;
            for (int index3 = 0; index3 < LoadRenderer.floats.size; index3 += 2)
            {
              float num16 = LoadRenderer.floats.items[index3];
              float num17 = LoadRenderer.floats.items[index3 + 1];
              num18 = Math.min(num16, num18);
              num19 = Math.min(num17, num19);
              num20 = Math.max(num16, num20);
              num21 = Math.max(num17, num21);
            }
            Draw.flush();
            Gl.clear(1024);
            Draw.beginStencil();
            Fill.poly(LoadRenderer.floats);
            Draw.beginStenciled();
            GlyphLayout glyphLayout1 = GlyphLayout.obtain();
            float num22 = 4f;
            switch (num11)
            {
              case 0:
                GlyphLayout glyphLayout2 = glyphLayout1;
                Font font2 = font1;
                object assetText1 = (object) this.assetText;
                charSequence1.__\u003Cref\u003E = (__Null) assetText1;
                CharSequence str1 = charSequence1;
                glyphLayout2.setText(font2, str1);
                Font font3 = font1;
                StringBuilder assetText2 = this.assetText;
                double num23 = (double) (num18 + num22);
                float num24 = num21 - num22 + Math.max(0.0f, glyphLayout1.height - (num21 - num19));
                float num25 = (float) num23;
                object obj1 = (object) assetText2;
                charSequence1.__\u003Cref\u003E = (__Null) obj1;
                CharSequence str2 = charSequence1;
                double num26 = (double) num25;
                double num27 = (double) num24;
                font3.draw(str2, (float) num26, (float) num27);
                break;
              case 1:
                float num28 = num21 - num19;
                float num29 = num1 * 8f;
                int num30 = Math.min(ByteCodeHelper.f2i((num28 - num29) / (font1.getLineHeight() * 1.4f)), this.bars.Length);
                float num31 = (num28 - num29) / (float) num30;
                float num32 = num31 * 0.8f;
                for (int index3 = 0; index3 < num30; ++index3)
                {
                  LoadRenderer.Bar bar = this.bars[index3];
                  if (bar.valid())
                  {
                    Draw.color(!bar.red() ? LoadRenderer.color : LoadRenderer.colorRed);
                    float num16 = num21 - (float) index3 * num31 - num29 - num32;
                    float num17 = Mathf.clamp(bar.value());
                    float num33 = !Core.graphics.isPortrait() ? num20 - num18 - (num21 - num16) - num29 * 2f - num1 * 4f : num20 - num18;
                    float num34 = num18 + num29;
                    float y1_1 = num16;
                    float num35 = y1_1 + num32;
                    float num36 = y1_1;
                    Lines.square(num34 + num32 / 2f, num36 + num32 / 2f, num32 / 2f);
                    Fill.quad(num34 + num32, y1_1, num34 + num32, num35, num34 + num17 * num33 + num32, num35, num34 + num17 * num33, num36);
                    Draw.color(Color.__\u003C\u003Eblack);
                    Fill.quad(num34 + num17 * num33 + num32, num35, num34 + num17 * num33, num36, num34 + num33, num36, num34 + num33 + num32, num35);
                    font1.setColor(Color.__\u003C\u003Eblack);
                    GlyphLayout glyphLayout3 = glyphLayout1;
                    Font font4 = font1;
                    object text1 = (object) bar.text;
                    charSequence1.__\u003Cref\u003E = (__Null) text1;
                    CharSequence str3 = charSequence1;
                    glyphLayout3.setText(font4, str3);
                    Font font5 = font1;
                    string text2 = bar.text;
                    double num37 = (double) (num34 + num32 * 1.5f);
                    float num38 = num36 + num32 / 2f + glyphLayout1.height / 2f;
                    float num39 = (float) num37;
                    object obj2 = (object) text2;
                    charSequence1.__\u003Cref\u003E = (__Null) obj2;
                    CharSequence str4 = charSequence1;
                    double num40 = (double) num39;
                    double num41 = (double) num38;
                    font5.draw(str4, (float) num40, (float) num41);
                  }
                }
                Draw.color(LoadRenderer.color);
                break;
              case 2:
                float num42 = 30f * num1;
                float num43 = 40f * num1;
                float num44 = 10f * num1;
                int num45 = ByteCodeHelper.f2i(num20 - num18 / num43) + 1;
                int num46 = ByteCodeHelper.f2i((num21 - num19) / num43);
                for (int index3 = 0; index3 < num45; ++index3)
                {
                  int num16 = index3;
                  int windowSize = this.renderTimes.getWindowSize();
                  float num17 = this.renderTimes.get(windowSize != -1 ? num16 % windowSize : 0);
                  float num33 = Mathf.clamp(this.renderTimes.hasEnoughData() ? num17 / this.renderTimes.mean() - 0.5f : Mathf.randomSeed((long) index3));
                  Color color = (double) num33 <= 0.800000011920929 ? LoadRenderer.color : LoadRenderer.colorRed;
                  Draw.color(color);
                  int num34 = Math.max(ByteCodeHelper.f2i(num33 * (float) num46), 1);
                  float x2 = num20 - num42 / 2f - num44 - (float) index3 * num43;
                  for (int index4 = 0; index4 < num46; ++index4)
                  {
                    if (index4 >= num34)
                      Draw.color(LoadRenderer.color, Color.__\u003C\u003Eblack, 0.7f);
                    else
                      Draw.color(color);
                    Fill.square(x2, num19 + (float) index4 * num43 + num42 / 2f + num44, num42 / 2f);
                  }
                }
                Draw.color(LoadRenderer.color);
                break;
              case 3:
                Draw.flush();
                float num47 = LoadRenderer.floats.get(6);
                float num48 = LoadRenderer.floats.get(7);
                float num49 = num20 - num47;
                float num50 = num21 - num48;
                float x3 = num47 + num49 / 2f;
                float y2 = num48 + num50 / 2f;
                float num51 = 30f * num1;
                float num52 = Math.min(num49, num50);
                float num53 = num52 - num51 * 2f;
                int num54 = ByteCodeHelper.f2i(num47 + num49 / 2f - num53 / 2f);
                int num55 = ByteCodeHelper.f2i(num48 + num50 / 2f - num53 / 2f);
                int width3 = ByteCodeHelper.f2i(num53);
                int height3 = ByteCodeHelper.f2i(num53);
                float len = num53 / 2f + num51;
                if (!Core.graphics.isPortrait())
                {
                  string str3 = "<<ready>>";
                  GlyphLayout glyphLayout3 = glyphLayout1;
                  Font font4 = font1;
                  object obj2 = (object) str3;
                  charSequence1.__\u003Cref\u003E = (__Null) obj2;
                  CharSequence str4 = charSequence1;
                  glyphLayout3.setText(font4, str4);
                  if ((double) (glyphLayout1.width * 1.5f) < (double) num49)
                  {
                    Lines.circle(x3, y2, num53 / 2f);
                    if (width3 > 0 && height3 > 0)
                    {
                      Gl.viewport(x1 + num54, y1 + num55, width3, height3);
                      this.cam.__\u003C\u003Eposition.set(2f, 0.0f, 2f);
                      this.cam.resize((float) width3, (float) height3);
                      this.cam.lookAt(0.0f, 0.0f, 0.0f);
                      this.cam.fov = 42f;
                      this.cam.update();
                      Shaders.mesh.bind();
                      Shaders.mesh.setUniformMatrix4("u_proj", this.cam.__\u003C\u003Ecombined.__\u003C\u003Eval);
                      this.mesh.render((Shader) Shaders.mesh, 1);
                      Gl.viewport(x1, y1, width2, height2);
                    }
                    int num16 = 4;
                    for (int index3 = 0; index3 < num16; ++index3)
                    {
                      float num17 = (float) index3 * 360f / (float) num16 + 45f;
                      Fill.poly(x3 + Angles.trnsx(num17, len), y2 + Angles.trnsy(num17, len), 3, 20f * num1, num17);
                    }
                    Draw.color(Color.__\u003C\u003Eblack);
                    Fill.rect(x3, y2, glyphLayout1.width + 14f * num1, glyphLayout1.height + 14f * num1);
                    font1.setColor(LoadRenderer.color);
                    Font font5 = font1;
                    string str5 = str3;
                    double num33 = (double) (x3 - glyphLayout1.width / 2f);
                    float num34 = y2 + glyphLayout1.height / 2f;
                    float num35 = (float) num33;
                    object obj3 = (object) str5;
                    charSequence1.__\u003Cref\u003E = (__Null) obj3;
                    CharSequence str6 = charSequence1;
                    double num36 = (double) num35;
                    double num37 = (double) num34;
                    font5.draw(str6, (float) num36, (float) num37);
                    Draw.color(LoadRenderer.color);
                    Lines.square(x3, y2, num52 / 2f);
                    Lines.line(num47, num48, num47, num48 + num50);
                    float num38 = 70f * num1;
                    int num39 = ByteCodeHelper.f2i(num50 / num38 / 2f) + 2;
                    float num40 = (num49 - num52) / 2f;
                    float num41 = num40 / 2f;
                    int[] signs3 = Mathf.__\u003C\u003Esigns;
                    int length3 = signs3.Length;
                    for (int index3 = 0; index3 < length3; ++index3)
                    {
                      int num17 = signs3[index3];
                      float num56 = x3 + (float) num17 * (num52 / 2f + num40 / 2f);
                      float num57 = num56 - num40 / 2f;
                      float num58 = num56 + num40 / 2f;
                      for (int index4 = -2; index4 < num39 * 2; ++index4)
                      {
                        float num59 = num48 + (float) index4 * num38 * 2f;
                        float y1_1 = num59 - num41;
                        float y4 = num59 + num41;
                        Fill.quad(num57, y1_1, num57, y1_1 + num38, num58, y4 + num38, num58, y4);
                      }
                    }
                  }
                  else
                  {
                    Lines.line(num47, num48, num47 + num49, num48 + num50);
                    Lines.line(num47, num48 + num50, num47 + num49, num48);
                  }
                }
                float num60 = 70f * num1;
                float num61 = 5f * num1;
                int num62 = ByteCodeHelper.f2i(num50 / num60) + 1;
                for (int index3 = 0; index3 < num62; ++index3)
                {
                  for (int index4 = 0; index4 < num62; ++index4)
                  {
                    float x2 = num47 - num60 / 2f - num60 * (float) index3 - num61;
                    float y3 = num48 + num50 - num60 / 2f - num60 * (float) index4 - num61;
                    Draw.color((double) Mathf.randomSeed(Pack.longInt(index3 + 91, index4 + 55)) >= 0.5 * (double) (1f - progress) ? LoadRenderer.color : LoadRenderer.colorRed);
                    Fill.square(x2, y3, num60 / 2.5f, 0.0f);
                    Draw.color(Color.__\u003C\u003Eblack);
                    Fill.square(x2, y3, num60 / 2.5f / Mathf.__\u003C\u003Esqrt2, 0.0f);
                  }
                }
                Draw.color(LoadRenderer.color);
                break;
            }
            glyphLayout1.free();
            Draw.endStencil();
            Lines.polyline(LoadRenderer.floats, true);
            ++num11;
          }
        }
      }
      Draw.flush();
      Gl.viewport(0, 0, Core.graphics.getWidth(), Core.graphics.getHeight());
      Draw.proj(0.0f, 0.0f, (float) Core.graphics.getWidth(), (float) Core.graphics.getHeight());
      float width4 = (float) Core.graphics.getWidth();
      float height4 = (float) Core.graphics.getHeight();
      float num63 = num1 * 100f;
      float num64 = num1 * 80f;
      int num65 = ByteCodeHelper.f2i(width4 / num63 / 2f) + 1;
      float num66 = 1f / (float) num65;
      float num67 = 1.5f;
      Draw.color(Color.__\u003C\u003Eblack);
      Fill.rect(width4 / 2f, height4 / 2f, width4, num64 * num67);
      Lines.stroke(thick);
      Draw.color(LoadRenderer.color);
      Lines.rect(0.0f, height4 / 2f - num64 * num67 / 2f, width4, num64 * num67, 10f, 0.0f);
      for (int index1 = 1; index1 < num65; ++index1)
      {
        float num11 = (float) index1 * num63;
        float num12 = 1f - (float) (index1 - 1) / (float) (num65 - 1);
        float s = (double) progress < (double) num12 ? Mathf.clamp((num66 - (num12 - progress)) / num66) : 1f;
        Draw.color(Color.__\u003C\u003Eblack, LoadRenderer.color, s);
        int[] signs = Mathf.__\u003C\u003Esigns;
        int length = signs.Length;
        for (int index2 = 0; index2 < length; ++index2)
        {
          int num13 = signs[index2];
          float w = num64 / 1.7f;
          float num14 = num64 / 2f;
          float x2 = width4 / 2f + num11 * (float) num13 - w / 2f;
          Fill.rects(x2 + (float) num13 * num14, height4 / 2f - num64 / 2f + num64 / 2f, w, num64 / 2f, (float) -num13 * num14);
          Fill.rects(x2, height4 / 2f - num64 / 2f, w, num64 / 2f, (float) num13 * num14);
        }
      }
      float num68 = 1f - -1f / (float) (num65 - 1);
      float s1 = (double) progress < (double) num68 ? Mathf.clamp((num66 - (num68 - progress)) / num66) : 1f;
      Draw.color(Color.__\u003C\u003Eblack, LoadRenderer.color, s1);
      Fill.square(width4 / 2f, height4 / 2f, num64 / 3f, 45f);
      if (Core.assets.isLoaded("tech"))
      {
        string str1 = Core.assets.getCurrentLoading() == null ? "system" : String.instancehelper_toLowerCase(Core.assets.getCurrentLoading().__\u003C\u003EfileName);
        string str2 = str1;
        object obj1 = (object) "script";
        charSequence1.__\u003Cref\u003E = (__Null) obj1;
        CharSequence charSequence2 = charSequence1;
        string str3;
        if (String.instancehelper_contains(str2, charSequence2))
        {
          str3 = "scripts";
        }
        else
        {
          string str4 = str1;
          object obj2 = (object) "content";
          charSequence1.__\u003Cref\u003E = (__Null) obj2;
          CharSequence charSequence3 = charSequence1;
          if (String.instancehelper_contains(str4, charSequence3))
          {
            str3 = "content";
          }
          else
          {
            string str5 = str1;
            object obj3 = (object) "mod";
            charSequence1.__\u003Cref\u003E = (__Null) obj3;
            CharSequence charSequence4 = charSequence1;
            if (String.instancehelper_contains(str5, charSequence4))
            {
              str3 = "mods";
            }
            else
            {
              string str6 = str1;
              object obj4 = (object) "msav";
              charSequence1.__\u003Cref\u003E = (__Null) obj4;
              CharSequence charSequence5 = charSequence1;
              if (!String.instancehelper_contains(str6, charSequence5))
              {
                string str7 = str1;
                object obj5 = (object) "maps";
                charSequence1.__\u003Cref\u003E = (__Null) obj5;
                CharSequence charSequence6 = charSequence1;
                if (!String.instancehelper_contains(str7, charSequence6))
                {
                  string str8 = str1;
                  object obj6 = (object) "ogg";
                  charSequence1.__\u003Cref\u003E = (__Null) obj6;
                  CharSequence charSequence7 = charSequence1;
                  if (!String.instancehelper_contains(str8, charSequence7))
                  {
                    string str9 = str1;
                    object obj7 = (object) "mp3";
                    charSequence1.__\u003Cref\u003E = (__Null) obj7;
                    CharSequence charSequence8 = charSequence1;
                    if (!String.instancehelper_contains(str9, charSequence8))
                    {
                      string str10 = str1;
                      object obj8 = (object) "png";
                      charSequence1.__\u003Cref\u003E = (__Null) obj8;
                      CharSequence charSequence9 = charSequence1;
                      str3 = !String.instancehelper_contains(str10, charSequence9) ? "system" : "image";
                      goto label_96;
                    }
                  }
                  str3 = "sound";
                  goto label_96;
                }
              }
              str3 = "map";
            }
          }
        }
label_96:
        string str11 = str3;
        Font font1 = (Font) Core.assets.get("tech");
        font1.setColor(Pal.accent);
        Draw.color(Color.__\u003C\u003Eblack);
        Font font2 = font1;
        string str12 = new StringBuilder().append(LoadRenderer.red).append("[[[[ ").append(str11).append(" ]]\n").append(LoadRenderer.orange).append("<").append(mindustry.core.Version.modifier).append("  ").append(mindustry.core.Version.build != 0 ? mindustry.core.Version.buildString() : "[init]").append(">").toString();
        double num11 = (double) (width4 / 2f);
        double num12 = (double) (height4 / 2f + 110f * num1);
        int num13 = 1;
        float num14 = (float) num12;
        float num15 = (float) num11;
        object obj9 = (object) str12;
        charSequence1.__\u003Cref\u003E = (__Null) obj9;
        CharSequence str13 = charSequence1;
        double num16 = (double) num15;
        double num17 = (double) num14;
        int halign = num13;
        font2.draw(str13, (float) num16, (float) num17, halign);
      }
      Draw.flush();
      this.fx.end();
      this.fx.applyEffects();
      this.fx.render();
    }

    [LineNumberTable(new byte[] {20, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.mesh.dispose();
      this.fx.dispose();
    }

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00240() => Core.assets != null;

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u00241() => Core.assets.getProgress();

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00242() => false;

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00243() => true;

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u00244() => (float) Core.app.getJavaHeap() / 1024f / 1024f / 200f;

    [Modifiers]
    [LineNumberTable(58)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00245() => Core.app.getJavaHeap() > 115343360L;

    [Modifiers]
    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00246() => mindustry.core.Version.build != 0;

    [Modifiers]
    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u00247() => mindustry.core.Version.build == -1 ? 0.3f : ((float) mindustry.core.Version.build - 103f) / 10f;

    [Modifiers]
    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00248() => !String.instancehelper_equals(mindustry.core.Version.modifier, (object) "release");

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00249() => Vars.control != null && Vars.control.saves != null;

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u002410() => (float) Vars.control.saves.getSaveSlots().size / 30f;

    [Modifiers]
    [LineNumberTable(61)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002411() => Vars.control.saves.getSaveSlots().size > 30;

    [Modifiers]
    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002412() => Core.settings.keySize() > 0;

    [Modifiers]
    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u002413() => (float) Core.settings.keySize() / 50f;

    [Modifiers]
    [LineNumberTable(62)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002414() => Core.settings.keySize() > 20;

    [Modifiers]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002415() => Vars.mods != null;

    [Modifiers]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static float lambda\u0024new\u002416() => (float) (Vars.mods.list().size + 1) / 6f;

    [Modifiers]
    [LineNumberTable(63)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u002417() => Vars.mods.list().size > 0;

    [LineNumberTable(new byte[] {159, 136, 109, 127, 4, 126, 127, 14, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LoadRenderer()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.graphics.LoadRenderer"))
        return;
      Color.__\u003Cclinit\u003E();
      LoadRenderer.color = new Color(Pal.accent).lerp(Color.__\u003C\u003Eblack, 0.5f);
      LoadRenderer.colorRed = Pal.breakInvalid.cpy().lerp(Color.__\u003C\u003Eblack, 0.3f);
      LoadRenderer.red = new StringBuilder().append("[#").append((object) LoadRenderer.colorRed).append("]").toString();
      LoadRenderer.orange = new StringBuilder().append("[#").append((object) LoadRenderer.color).append("]").toString();
      LoadRenderer.floats = new FloatSeq();
    }

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    internal class Bar : Object
    {
      [Modifiers]
      internal Floatp value;
      [Modifiers]
      internal Boolp red;
      [Modifiers]
      internal Boolp valid;
      [Modifiers]
      internal string text;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static float lambda\u0024new\u00240([In] float obj0) => obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00241([In] bool obj0) => obj0;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024new\u00242() => true;

      [LineNumberTable(new byte[] {159, 20, 98, 104, 114, 113, 112, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Bar([In] string obj0, [In] float obj1, [In] bool obj2)
      {
        int num = obj2 ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LoadRenderer.Bar bar = this;
        this.value = (Floatp) new LoadRenderer.Bar.__\u003C\u003EAnon0(obj1);
        this.red = (Boolp) new LoadRenderer.Bar.__\u003C\u003EAnon1(num != 0);
        this.valid = (Boolp) new LoadRenderer.Bar.__\u003C\u003EAnon2();
        this.text = obj0;
      }

      [LineNumberTable(new byte[] {161, 126, 104, 103, 103, 104, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Bar([In] string obj0, [In] Boolp obj1, [In] Floatp obj2, [In] Boolp obj3)
      {
        LoadRenderer.Bar bar = this;
        this.valid = obj1;
        this.value = obj2;
        this.red = obj3;
        this.text = obj0;
      }

      [LineNumberTable(504)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool valid() => this.valid.get();

      [LineNumberTable(508)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool red() => this.red.get();

      [LineNumberTable(512)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual float value() => Mathf.clamp(this.value.get());

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Floatp
      {
        private readonly float arg\u00241;

        internal __\u003C\u003EAnon0([In] float obj0) => this.arg\u00241 = obj0;

        public float get() => LoadRenderer.Bar.lambda\u0024new\u00240(this.arg\u00241);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Boolp
      {
        private readonly bool arg\u00241;

        internal __\u003C\u003EAnon1([In] bool obj0) => this.arg\u00241 = obj0;

        public bool get() => (LoadRenderer.Bar.lambda\u0024new\u00241(this.arg\u00241) ? 1 : 0) != 0;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : Boolp
      {
        internal __\u003C\u003EAnon2()
        {
        }

        public bool get() => (LoadRenderer.Bar.lambda\u0024new\u00242() ? 1 : 0) != 0;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolp
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00240() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Floatp
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public float get() => LoadRenderer.lambda\u0024new\u00241();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolp
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00242() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Boolp
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00243() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Floatp
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public float get() => LoadRenderer.lambda\u0024new\u00244();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolp
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00245() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolp
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00246() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Floatp
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public float get() => LoadRenderer.lambda\u0024new\u00247();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Boolp
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00248() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Boolp
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u00249() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Floatp
    {
      internal __\u003C\u003EAnon10()
      {
      }

      public float get() => LoadRenderer.lambda\u0024new\u002410();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Boolp
    {
      internal __\u003C\u003EAnon11()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u002411() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Boolp
    {
      internal __\u003C\u003EAnon12()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u002412() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Floatp
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public float get() => LoadRenderer.lambda\u0024new\u002413();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Boolp
    {
      internal __\u003C\u003EAnon14()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u002414() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Boolp
    {
      internal __\u003C\u003EAnon15()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u002415() ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Floatp
    {
      internal __\u003C\u003EAnon16()
      {
      }

      public float get() => LoadRenderer.lambda\u0024new\u002416();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Boolp
    {
      internal __\u003C\u003EAnon17()
      {
      }

      public bool get() => (LoadRenderer.lambda\u0024new\u002417() ? 1 : 0) != 0;
    }
  }
}
