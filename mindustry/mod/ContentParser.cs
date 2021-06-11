// Decompiled with JetBrains decompiler
// Type: mindustry.mod.ContentParser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.assets;
using arc.assets.loaders;
using arc.audio;
using arc.files;
using arc.func;
using arc.graphics;
using arc.graphics.g2d;
using arc.math;
using arc.util;
using arc.util.serialization;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.lang.reflect;
using java.util;
using mindustry.ai.types;
using mindustry.content;
using mindustry.ctype;
using mindustry.entities;
using mindustry.entities.abilities;
using mindustry.entities.bullet;
using mindustry.entities.effect;
using mindustry.game;
using mindustry.gen;
using mindustry.type;
using mindustry.type.weather;
using mindustry.world;
using mindustry.world.blocks.units;
using mindustry.world.consumers;
using mindustry.world.draw;
using mindustry.world.meta;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.mod
{
  public class ContentParser : Object
  {
    private const bool ignoreUnknownFields = true;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Lmindustry/ctype/ContentType;>;")]
    internal ObjectMap contentTypes;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/Class<*>;>;")]
    internal ObjectSet implicitNullable;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/assets/AssetDescriptor<*>;>;")]
    internal ObjectMap sounds;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Lmindustry/mod/ContentParser$FieldParser;>;")]
    internal ObjectMap classParsers;
    [Signature("Larc/struct/Seq<Ljava/lang/Runnable;>;")]
    private Seq reads;
    [Signature("Larc/struct/Seq<Ljava/lang/Runnable;>;")]
    private Seq postreads;
    [Signature("Larc/struct/ObjectSet<Ljava/lang/Object;>;")]
    private ObjectSet toBeParsed;
    internal Mods.LoadedMod currentMod;
    internal Content currentContent;
    private Json parser;
    [Signature("Larc/struct/ObjectMap<Lmindustry/ctype/ContentType;Lmindustry/mod/ContentParser$TypeParser<*>;>;")]
    private ObjectMap parsers;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [LineNumberTable(new byte[] {161, 244, 140, 109, 103, 109, 109, 127, 43, 132, 127, 46, 229, 71, 137, 255, 71, 75, 229, 54, 98, 127, 45, 98, 127, 29, 104, 98, 105, 109, 127, 29, 232, 40, 236, 92, 255, 17, 71, 104, 104, 133, 109, 223, 19, 125, 100, 167, 121, 136, 254, 89})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void readFields([In] object obj0, [In] JsonValue obj1)
    {
      JsonValue jsonValue = obj1.remove("research");
      this.toBeParsed.remove(obj0);
      Class type = Object.instancehelper_getClass(obj0);
      OrderedMap fields = this.parser.getFields(type);
      for (JsonValue jsonData = obj1.child; jsonData != null; jsonData = jsonData.next)
      {
        OrderedMap orderedMap = fields;
        string str1 = jsonData.name();
        object obj2 = (object) "_";
        object obj3 = (object) " ";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence2 = charSequence1;
        object obj4 = obj2;
        charSequence1.__\u003Cref\u003E = (__Null) obj4;
        CharSequence charSequence3 = charSequence1;
        string str2 = String.instancehelper_replace(str1, charSequence2, charSequence3);
        Json.FieldMetadata fieldMetadata = (Json.FieldMetadata) orderedMap.get((object) str2);
        if (fieldMetadata == null)
        {
          Log.warn(new StringBuilder().append("@: Ignoring unknown field: ").append(jsonData.name).append(" (").append(type.getName()).append(")").toString(), obj0);
        }
        else
        {
          Field field = fieldMetadata.__\u003C\u003Efield;
          IllegalAccessException illegalAccessException1;
          SerializationException serializationException1;
          RuntimeException runtimeException;
          try
          {
            try
            {
              try
              {
                field.set(obj0, this.parser.readValue(field.getType(), fieldMetadata.elementType, jsonData, fieldMetadata.keyType), ContentParser.__\u003CGetCallerID\u003E());
                continue;
              }
              catch (IllegalAccessException ex)
              {
                illegalAccessException1 = (IllegalAccessException) ByteCodeHelper.MapException<IllegalAccessException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              }
            }
            catch (SerializationException ex)
            {
              serializationException1 = (SerializationException) ByteCodeHelper.MapException<SerializationException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
              goto label_12;
            }
          }
          catch (Exception ex)
          {
            M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
            if (m0 == null)
            {
              throw;
            }
            else
            {
              runtimeException = (RuntimeException) m0;
              goto label_13;
            }
          }
          IllegalAccessException illegalAccessException2 = illegalAccessException1;
          string message = new StringBuilder().append("Error accessing field: ").append(field.getName()).append(" (").append(type.getName()).append(")").toString();
          IllegalAccessException illegalAccessException3 = illegalAccessException2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new SerializationException(message, (Exception) illegalAccessException3);
label_12:
          SerializationException serializationException2 = serializationException1;
          serializationException2.addTrace(new StringBuilder().append(field.getName()).append(" (").append(type.getName()).append(")").toString());
          throw Throwable.__\u003Cunmap\u003E((Exception) serializationException2);
label_13:
          SerializationException serializationException3 = new SerializationException((Exception) runtimeException);
          serializationException3.addTrace(jsonData.trace());
          serializationException3.addTrace(new StringBuilder().append(field.getName()).append(" (").append(type.getName()).append(")").toString());
          throw Throwable.__\u003Cunmap\u003E((Exception) serializationException3);
        }
      }
      object obj = obj0;
      UnlockableContent content;
      if (!(obj is UnlockableContent) || !object.ReferenceEquals((object) (content = (UnlockableContent) obj), (object) (UnlockableContent) obj) || jsonValue == null)
        return;
      string str;
      ItemStack[] itemStackArray;
      if (jsonValue.isString())
      {
        str = jsonValue.asString();
        itemStackArray = (ItemStack[]) null;
      }
      else
      {
        str = jsonValue.getString("parent");
        itemStackArray = !jsonValue.has("requirements") ? (ItemStack[]) null : (ItemStack[]) this.parser.readValue((Class) ClassLiteral<ItemStack[]>.Value, jsonValue.get("requirements"));
      }
      ((TechTree.TechNode) TechTree.all.find((Boolf) new ContentParser.__\u003C\u003EAnon16(content)))?.remove();
      TechTree.TechNode techNode = new TechTree.TechNode((TechTree.TechNode) null, content, itemStackArray ?? content.researchRequirements());
      Mods.LoadedMod currentMod = this.currentMod;
      this.postreads.add((object) (Runnable) new ContentParser.__\u003C\u003EAnon17(this, content, currentMod, techNode, str));
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;)Ljava/lang/Class<TT;>;")]
    [LineNumberTable(700)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Class resolve([In] string obj0) => this.resolve(obj0, (Class) null);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(new byte[] {161, 164, 114, 103, 127, 13, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object make([In] Class obj0)
    {
      object obj;
      Exception exception1;
      try
      {
        Constructor declaredConstructor = obj0.getDeclaredConstructor(new Class[0], ContentParser.__\u003CGetCallerID\u003E());
        ((AccessibleObject) declaredConstructor).setAccessible(true);
        obj = declaredConstructor.newInstance(new object[0], ContentParser.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;)Ljava/lang/Class<TT;>;")]
    [LineNumberTable(new byte[] {162, 80, 173, 127, 16, 165, 153, 127, 5, 129, 127, 5, 136, 127, 15, 129, 194, 99, 127, 66, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual Class resolve([In] string obj0, [In] Class obj1)
    {
      if (String.instancehelper_isEmpty(obj0) && obj1 != null)
        return obj1;
      Class class1 = (Class) ClassMap.__\u003C\u003Eclasses.get(String.instancehelper_isEmpty(obj0) || !Character.isLowerCase(String.instancehelper_charAt(obj0, 0)) ? (object) obj0 : (object) Strings.capitalize(obj0));
      if (class1 != null)
        return class1;
      if (String.instancehelper_indexOf(obj0, 46) != -1)
      {
        if (Scripts.allowClass(obj0))
        {
          Class class2;
          try
          {
            class2 = Class.forName(obj0, ContentParser.__\u003CGetCallerID\u003E());
          }
          catch (Exception ex)
          {
            if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
              throw;
            else
              goto label_10;
          }
          return class2;
label_10:
          Iterator iterator = Vars.mods.mods.iterator();
          while (iterator.hasNext())
          {
            Mods.LoadedMod loadedMod = (Mods.LoadedMod) iterator.next();
            if (loadedMod.loader != null)
            {
              Class class3;
              try
              {
                class3 = Class.forName(obj0, true, loadedMod.loader, ContentParser.__\u003CGetCallerID\u003E());
              }
              catch (Exception ex)
              {
                if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
                  throw;
                else
                  goto label_17;
              }
              return class3;
label_17:;
            }
          }
        }
      }
      if (obj1 != null)
      {
        Log.warn(new StringBuilder().append("[@] No type '").append(obj0).append("' found, defaulting to type '").append(obj1.getSimpleName()).append("'").toString(), this.currentContent != null ? (object) "" : (object) this.currentMod.__\u003C\u003Ename);
        return obj1;
      }
      string str = new StringBuilder().append("Type not found: ").append(obj0).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [Signature("(Ljava/lang/Class<*>;Larc/util/serialization/JsonValue;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {161, 214, 127, 22, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object fieldOpt([In] Class obj0, [In] JsonValue obj1)
    {
      object obj;
      try
      {
        obj = obj0.getField(obj1.asString(), ContentParser.__\u003CGetCallerID\u003E()).get((object) null, ContentParser.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_4;
      }
      return obj;
label_4:
      return (object) null;
    }

    [Signature("(Ljava/lang/Class<*>;Larc/util/serialization/JsonValue;)Ljava/lang/Object;")]
    [LineNumberTable(568)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual object field([In] Class obj0, [In] JsonValue obj1) => this.field(obj0, obj1.asString());

    [Signature("<T:Lmindustry/ctype/Content;>(Lmindustry/ctype/ContentType;Larc/func/Func<Ljava/lang/String;TT;>;)Lmindustry/mod/ContentParser$TypeParser<TT;>;")]
    [LineNumberTable(364)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ContentParser.TypeParser parser([In] ContentType obj0, [In] Func obj1) => (ContentParser.TypeParser) new ContentParser.__\u003C\u003EAnon10(this, obj0, obj1);

    [LineNumberTable(new byte[] {160, 231, 105, 136})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getString([In] JsonValue obj0, [In] string obj1)
    {
      if (obj0.has(obj1))
        return obj0.getString(obj1);
      string str = new StringBuilder().append("You are missing a \"").append(obj1).append("\". It must be added before the file can be parsed.").toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [Signature("<T:Lmindustry/ctype/MappableContent;>(Lmindustry/ctype/ContentType;Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {161, 158, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private MappableContent locate([In] ContentType obj0, [In] string obj1) => Vars.content.getByName(obj0, obj1) ?? Vars.content.getByName(obj0, new StringBuilder().append(this.currentMod.__\u003C\u003Ename).append("-").append(obj1).toString());

    [LineNumberTable(new byte[] {161, 132, 112, 158})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void markError(Content content, Exception error)
    {
      if (content.minfo == null || content.hasErrored())
        return;
      this.markError(content, content.minfo.mod, content.minfo.sourceFile, error);
    }

    [LineNumberTable(new byte[] {161, 51, 118, 109, 108, 147, 127, 26, 171, 239, 55, 233, 76})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void init()
    {
      ContentType[] all = ContentType.__\u003C\u003Eall;
      int length = all.Length;
      for (int index = 0; index < length; ++index)
      {
        ContentType type = all[index];
        Seq by = Vars.content.getBy(type);
        if (!by.isEmpty())
        {
          Class superclass = Object.instancehelper_getClass((object) (Content) by.first());
          while (!object.ReferenceEquals((object) superclass.getSuperclass(), (object) ClassLiteral<Content>.Value) && !object.ReferenceEquals((object) superclass.getSuperclass(), (object) ClassLiteral<UnlockableContent>.Value) && !Modifier.isAbstract(superclass.getSuperclass().getModifiers()))
            superclass = superclass.getSuperclass();
          this.contentTypes.put((object) superclass, (object) type);
        }
      }
    }

    [LineNumberTable(new byte[] {161, 138, 102, 159, 12, 112, 127, 7, 104, 146, 103, 126, 127, 56, 101, 107, 63, 92, 106, 102, 133})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string makeError([In] Exception obj0, [In] Fi obj1)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.append("[lightgray]").append("File: ").append(obj1.name()).append("[]\n\n");
      if (Throwable.instancehelper_getMessage(obj0) != null && obj0 is Jval.JsonParseException)
        stringBuilder1.append("[accent][[JsonParse][] ").append(":\n").append(Throwable.instancehelper_getMessage(obj0));
      else if (obj0 is NullPointerException)
      {
        stringBuilder1.append(Strings.neatError(obj0));
      }
      else
      {
        Iterator iterator = Strings.getCauses(obj0).iterator();
        while (iterator.hasNext())
        {
          Exception exception = (Exception) iterator.next();
          StringBuilder stringBuilder2 = stringBuilder1.append("[accent][[");
          string simpleName = Object.instancehelper_getClass((object) exception).getSimpleName();
          object obj2 = (object) "";
          object obj3 = (object) "Exception";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence2 = charSequence1;
          object obj4 = obj2;
          charSequence1.__\u003Cref\u003E = (__Null) obj4;
          CharSequence charSequence3 = charSequence1;
          string str1 = String.instancehelper_replace(simpleName, charSequence2, charSequence3);
          StringBuilder stringBuilder3 = stringBuilder2.append(str1).append("][] ");
          string str2;
          if (Throwable.instancehelper_getMessage(exception) != null)
          {
            string message = Throwable.instancehelper_getMessage(exception);
            object obj5 = (object) "";
            object obj6 = (object) "mindustry.";
            charSequence1.__\u003Cref\u003E = (__Null) obj6;
            CharSequence charSequence4 = charSequence1;
            object obj7 = obj5;
            charSequence1.__\u003Cref\u003E = (__Null) obj7;
            CharSequence charSequence5 = charSequence1;
            string str3 = String.instancehelper_replace(message, charSequence4, charSequence5);
            object obj8 = (object) "";
            object obj9 = (object) "arc.";
            charSequence1.__\u003Cref\u003E = (__Null) obj9;
            CharSequence charSequence6 = charSequence1;
            object obj10 = obj8;
            charSequence1.__\u003Cref\u003E = (__Null) obj10;
            CharSequence charSequence7 = charSequence1;
            str2 = String.instancehelper_replace(str3, charSequence6, charSequence7);
          }
          else
            str2 = "";
          stringBuilder3.append(str2).append("\n");
        }
      }
      return stringBuilder1.toString();
    }

    [LineNumberTable(new byte[] {161, 120, 159, 3, 108, 108, 116, 109, 99, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void markError(Content content, Mods.LoadedMod mod, Fi file, Exception error)
    {
      Log.err("Error for @ / @:\n@\n", (object) content, (object) file, (object) Strings.getStackTrace(error));
      content.minfo.mod = mod;
      content.minfo.sourceFile = file;
      content.minfo.error = this.makeError(error, file);
      content.minfo.baseError = error;
      mod?.erroredContent.add((object) content);
    }

    [Signature("(Ljava/lang/Class<*>;Ljava/lang/String;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {161, 204, 120, 127, 30, 124, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object field([In] Class obj0, [In] string obj1)
    {
      object obj2;
      Exception exception1;
      try
      {
        object obj3 = obj0.getField(obj1, ContentParser.__\u003CGetCallerID\u003E()).get((object) null, ContentParser.__\u003CGetCallerID\u003E());
        if (obj3 == null)
        {
          string str = new StringBuilder().append(obj0.getSimpleName()).append(": not found: '").append(obj1).append("'").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
        obj2 = obj3;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_7;
        }
      }
      return obj2;
label_7:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [LineNumberTable(new byte[] {161, 221, 159, 26, 255, 13, 77})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void checkNullFields([In] object obj0)
    {
      if (obj0 == null || obj0 is Number || (obj0 is string || this.toBeParsed.contains(obj0)) || String.instancehelper_startsWith(Object.instancehelper_getClass(obj0).getName(), "arc."))
        return;
      this.parser.getFields(Object.instancehelper_getClass(obj0)).values().toSeq().each((Cons) new ContentParser.__\u003C\u003EAnon15(this, obj0));
    }

    [LineNumberTable(new byte[] {161, 10, 159, 1, 127, 90, 102, 145, 112, 127, 7, 127, 18, 148, 172, 112, 127, 7, 127, 18, 148, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readBundle([In] ContentType obj0, [In] string obj1, [In] JsonValue obj2)
    {
      UnlockableContent unlockableContent = !(this.locate(obj0, obj1) is UnlockableContent) ? (UnlockableContent) null : (UnlockableContent) this.locate(obj0, obj1);
      string str = unlockableContent != null ? new StringBuilder().append((object) obj0).append(".").append(unlockableContent.__\u003C\u003Ename).append(".").toString() : new StringBuilder().append((object) obj0).append(".").append(this.currentMod.__\u003C\u003Ename).append("-").append(obj1).append(".").toString();
      I18NBundle i18Nbundle = Core.bundle;
      while (i18Nbundle.getParent() != null)
        i18Nbundle = i18Nbundle.getParent();
      if (obj2.has("name"))
      {
        if (!Core.bundle.has(new StringBuilder().append(str).append("name").toString()))
        {
          i18Nbundle.getProperties().put((object) new StringBuilder().append(str).append("name").toString(), (object) obj2.getString("name"));
          if (unlockableContent != null)
            unlockableContent.localizedName = obj2.getString("name");
        }
        obj2.remove("name");
      }
      if (!obj2.has("description"))
        return;
      if (!Core.bundle.has(new StringBuilder().append(str).append("description").toString()))
      {
        i18Nbundle.getProperties().put((object) new StringBuilder().append(str).append("description").toString(), (object) obj2.getString("description"));
        if (unlockableContent != null)
          unlockableContent.description = obj2.getString("description");
      }
      obj2.remove("description");
    }

    [LineNumberTable(new byte[] {161, 35, 103, 103, 249, 75})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void read([In] Runnable obj0) => this.reads.add((object) (Runnable) new ContentParser.__\u003C\u003EAnon11(this, this.currentMod, this.currentContent, obj0));

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private string getType([In] JsonValue obj0) => this.getString(obj0, "type");

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {161, 174, 122, 103, 127, 17, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private object make([In] Class obj0, [In] string obj1)
    {
      object obj;
      Exception exception1;
      try
      {
        Constructor declaredConstructor = obj0.getDeclaredConstructor(new Class[1]
        {
          (Class) ClassLiteral<String>.Value
        }, ContentParser.__\u003CGetCallerID\u003E());
        ((AccessibleObject) declaredConstructor).setAccessible(true);
        obj = declaredConstructor.newInstance(new object[1]
        {
          (object) obj1
        }, ContentParser.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Signature("(Larc/util/serialization/JsonValue;)Larc/func/Prov<Lmindustry/gen/Unit;>;")]
    [LineNumberTable(new byte[] {160, 219, 110, 127, 160, 95, 108, 108, 108, 108, 108, 255, 16, 58})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Prov unitType([In] JsonValue obj0)
    {
      if (obj0 == null)
        return (Prov) new ContentParser.__\u003C\u003EAnon5();
      string str1 = obj0.asString();
      int num = -1;
      switch (String.instancehelper_hashCode(str1))
      {
        case -1271344497:
          if (String.instancehelper_equals(str1, (object) "flying"))
          {
            num = 0;
            break;
          }
          break;
        case -786701938:
          if (String.instancehelper_equals(str1, (object) "payload"))
          {
            num = 4;
            break;
          }
          break;
        case 3317797:
          if (String.instancehelper_equals(str1, (object) "legs"))
          {
            num = 2;
            break;
          }
          break;
        case 3347453:
          if (String.instancehelper_equals(str1, (object) "mech"))
          {
            num = 1;
            break;
          }
          break;
        case 104593550:
          if (String.instancehelper_equals(str1, (object) "naval"))
          {
            num = 3;
            break;
          }
          break;
      }
      switch (num)
      {
        case 0:
          return (Prov) new ContentParser.__\u003C\u003EAnon5();
        case 1:
          return (Prov) new ContentParser.__\u003C\u003EAnon6();
        case 2:
          return (Prov) new ContentParser.__\u003C\u003EAnon7();
        case 3:
          return (Prov) new ContentParser.__\u003C\u003EAnon8();
        case 4:
          return (Prov) new ContentParser.__\u003C\u003EAnon9();
        default:
          string str2 = new StringBuilder().append("Invalid unit type: '").append((object) obj0).append("'. Must be 'flying/mech/legs/naval/payload'.").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str2);
      }
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)Larc/func/Prov<TT;>;")]
    [LineNumberTable(new byte[] {161, 184, 114, 255, 7, 71, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Prov supply([In] Class obj0)
    {
      Prov prov;
      Exception exception1;
      try
      {
        prov = (Prov) new ContentParser.__\u003C\u003EAnon14(obj0.getDeclaredConstructor(new Class[0], ContentParser.__\u003CGetCallerID\u003E()));
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return prov;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [LineNumberTable(new byte[] {158, 246, 98, 111, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void readFields([In] object obj0, [In] JsonValue obj1, [In] bool obj2)
    {
      if (obj2)
        obj1.remove("type");
      this.readFields(obj0, obj1);
    }

    [Signature("<T:Lmindustry/ctype/Content;>(Lmindustry/ctype/ContentType;Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {160, 243, 109, 127, 26, 127, 35})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Content find([In] ContentType obj0, [In] string obj1)
    {
      MappableContent mappableContent = Vars.content.getByName(obj0, obj1) ?? Vars.content.getByName(obj0, new StringBuilder().append(this.currentMod.__\u003C\u003Ename).append("-").append(obj1).toString());
      if (mappableContent == null)
      {
        string str = new StringBuilder().append("No ").append((object) obj0).append(" found with name '").append(obj1).append("'").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      return (Content) mappableContent;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 89, 205, 110, 146, 109, 191, 6, 191, 40, 135, 243, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Block lambda\u0024new\u00241([In] string obj0, [In] string obj1, [In] JsonValue obj2)
    {
      this.readBundle(ContentType.__\u003C\u003Eblock, obj1, obj2);
      Block block;
      if (this.locate(ContentType.__\u003C\u003Eblock, obj1) != null)
      {
        block = (Block) this.locate(ContentType.__\u003C\u003Eblock, obj1);
        if (obj2.has("type"))
        {
          string str = new StringBuilder().append("When defining properties for an existing block, you must not re-declare its type. The original type will be used. Block: ").append(obj1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
        }
      }
      else
        block = (Block) this.make(this.resolve(obj2.getString("type", ""), (Class) ClassLiteral<Block>.Value), new StringBuilder().append(obj0).append("-").append(obj1).toString());
      this.currentContent = (Content) block;
      this.read((Runnable) new ContentParser.__\u003C\u003EAnon22(this, obj2, block));
      return block;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 141, 173, 113, 127, 12, 140, 107, 191, 16, 109, 98, 178, 135, 243, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private UnitType lambda\u0024new\u00243([In] string obj0, [In] string obj1, [In] JsonValue obj2)
    {
      this.readBundle(ContentType.__\u003C\u003Eunit, obj1, obj2);
      UnitType unitType;
      if (this.locate(ContentType.__\u003C\u003Eunit, obj1) == null)
      {
        UnitType.__\u003Cclinit\u003E();
        unitType = new UnitType(new StringBuilder().append(obj0).append("-").append(obj1).toString());
        JsonValue jsonValue = obj2.get("type");
        if (jsonValue != null && !jsonValue.isString())
        {
          string str = new StringBuilder().append("Unit '").append(obj1).append("' has an incorrect type. Types must be strings.").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException(str);
        }
        unitType.constructor = this.unitType(jsonValue);
      }
      else
        unitType = (UnitType) this.locate(ContentType.__\u003C\u003Eunit, obj1);
      this.currentContent = (Content) unitType;
      this.read((Runnable) new ContentParser.__\u003C\u003EAnon21(this, obj2, unitType));
      return unitType;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 201, 110, 114, 143, 109, 127, 31, 140, 103, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Weather lambda\u0024new\u00245([In] string obj0, [In] string obj1, [In] JsonValue obj2)
    {
      Weather weather;
      if (this.locate(ContentType.__\u003C\u003Eweather, obj1) != null)
      {
        weather = (Weather) this.locate(ContentType.__\u003C\u003Eweather, obj1);
        this.readBundle(ContentType.__\u003C\u003Eweather, obj1, obj2);
      }
      else
      {
        this.readBundle(ContentType.__\u003C\u003Eweather, obj1, obj2);
        weather = (Weather) this.make(this.resolve(this.getType(obj2), (Class) ClassLiteral<ParticleWeather>.Value), new StringBuilder().append(obj0).append("-").append(obj1).toString());
        obj2.remove("type");
      }
      this.currentContent = (Content) weather;
      this.read((Runnable) new ContentParser.__\u003C\u003EAnon20(this, weather, obj2));
      return weather;
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [Modifiers]
    [LineNumberTable(new byte[] {160, 252, 107, 106, 141, 107, 159, 14, 103, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Content lambda\u0024parser\u00247(
      [In] ContentType obj0,
      [In] Func obj1,
      [In] string obj2,
      [In] string obj3,
      [In] JsonValue obj4)
    {
      Content content;
      if (this.locate(obj0, obj3) != null)
      {
        content = (Content) this.locate(obj0, obj3);
        this.readBundle(obj0, obj3, obj4);
      }
      else
      {
        this.readBundle(obj0, obj3, obj4);
        content = (Content) obj1.get((object) new StringBuilder().append(obj2).append("-").append(obj3).toString());
      }
      this.currentContent = content;
      this.read((Runnable) new ContentParser.__\u003C\u003EAnon19(this, content, obj4));
      return content;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 38, 103, 103, 166, 99, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024read\u00248([In] Mods.LoadedMod obj0, [In] Content obj1, [In] Runnable obj2)
    {
      this.currentMod = obj0;
      this.currentContent = obj1;
      obj2.run();
      if (obj1 == null)
        return;
      this.toBeParsed.remove((object) obj1);
      this.checkNullFields((object) obj1);
    }

    [LineNumberTable(new byte[] {161, 67, 248, 69, 226, 60, 97, 134, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void attempt([In] Runnable obj0)
    {
      Exception exception1;
      try
      {
        obj0.run();
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Log.err(exception2);
      this.markError(this.currentContent, exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 187, 127, 13, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object lambda\u0024supply\u00249([In] Constructor obj0)
    {
      object obj;
      Exception exception1;
      try
      {
        obj = obj0.newInstance(new object[0], ContentParser.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
        {
          throw;
        }
        else
        {
          exception1 = (Exception) m0;
          goto label_5;
        }
      }
      return obj;
label_5:
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 225, 151, 127, 39, 127, 10, 127, 43, 223, 59, 2, 97, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024checkNullFields\u002410([In] object obj0, [In] Json.FieldMetadata obj1)
    {
      Exception exception1;
      try
      {
        if (obj1.__\u003C\u003Efield.getType().isPrimitive() || ((AccessibleObject) obj1.__\u003C\u003Efield).isAnnotationPresent((Class) ClassLiteral<arc.util.Nullable>.Value) || (obj1.__\u003C\u003Efield.get(obj0, ContentParser.__\u003CGetCallerID\u003E()) != null || this.implicitNullable.contains((object) obj1.__\u003C\u003Efield.getType())))
          return;
        string str = new StringBuilder().append("'").append(obj1.__\u003C\u003Efield.getName()).append("' in ").append((!Object.instancehelper_getClass(obj0).isAnonymousClass() ? Object.instancehelper_getClass(obj0) : Object.instancehelper_getClass(obj0).getSuperclass()).getSimpleName()).append(" is missing! Object = ").append(obj0).append(", field = (").append(obj1.__\u003C\u003Efield.getName()).append(" = ").append(obj1.__\u003C\u003Efield.get(obj0, ContentParser.__\u003CGetCallerID\u003E())).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException(str);
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      Exception exception2 = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) exception2);
    }

    [Modifiers]
    [LineNumberTable(663)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024readFields\u002411(
      [In] UnlockableContent obj0,
      [In] TechTree.TechNode obj1)
    {
      return object.ReferenceEquals((object) obj1.content, (object) obj0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {162, 46, 103, 167, 104, 242, 69, 157, 99, 223, 38, 110, 172, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024readFields\u002413(
      [In] UnlockableContent obj0,
      [In] Mods.LoadedMod obj1,
      [In] TechTree.TechNode obj2,
      [In] string obj3)
    {
      this.currentContent = (Content) obj0;
      this.currentMod = obj1;
      if (obj2.parent != null)
        obj2.parent.__\u003C\u003Echildren.remove((object) obj2);
      TechTree.TechNode techNode = (TechTree.TechNode) TechTree.all.find((Boolf) new ContentParser.__\u003C\u003EAnon18(this, obj3));
      if (techNode == null)
      {
        string str = new StringBuilder().append("Content '").append(obj3).append("' isn't in the tech tree, but '").append(obj0.__\u003C\u003Ename).append("' requires it to be researched.").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (!techNode.__\u003C\u003Echildren.contains((object) obj2))
        techNode.__\u003C\u003Echildren.add((object) obj2);
      obj2.parent = techNode;
    }

    [Modifiers]
    [LineNumberTable(682)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024readFields\u002412([In] string obj0, [In] TechTree.TechNode obj1) => String.instancehelper_equals(obj1.content.__\u003C\u003Ename, (object) obj0) || String.instancehelper_equals(obj1.content.__\u003C\u003Ename, (object) new StringBuilder().append(this.currentMod.__\u003C\u003Ename).append("-").append(obj0).toString());

    [Modifiers]
    [LineNumberTable(374)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024parser\u00246([In] Content obj0, [In] JsonValue obj1) => this.readFields((object) obj0, obj1);

    [Modifiers]
    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00244([In] Weather obj0, [In] JsonValue obj1) => this.readFields((object) obj0, obj1);

    [Modifiers]
    [LineNumberTable(new byte[] {160, 161, 112, 140, 151, 127, 5, 107, 159, 1, 127, 6, 159, 1, 240, 69, 109, 127, 3, 204, 112, 108, 120, 121, 40, 200, 178, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00242([In] JsonValue obj0, [In] UnitType obj1)
    {
      if (obj0.has("requirements"))
      {
        JsonValue jsonData = obj0.remove("requirements");
        ContentParser.UnitReq unitReq = (ContentParser.UnitReq) this.parser.readValue((Class) ClassLiteral<ContentParser.UnitReq>.Value, jsonData);
        Block block1 = unitReq.block;
        Reconstructor reconstructor;
        if (block1 is Reconstructor && object.ReferenceEquals((object) (reconstructor = (Reconstructor) block1), (object) (Reconstructor) block1))
        {
          if (unitReq.previous != null)
            reconstructor.upgrades.add((object) new UnitType[2]
            {
              unitReq.previous,
              obj1
            });
        }
        else
        {
          Block block2 = unitReq.block;
          UnitFactory unitFactory;
          if (block2 is UnitFactory && object.ReferenceEquals((object) (unitFactory = (UnitFactory) block2), (object) (UnitFactory) block2))
          {
            unitFactory.plans.add((object) new UnitFactory.UnitPlan(obj1, unitReq.time, unitReq.requirements));
          }
          else
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException("Missing a valid 'block' in 'requirements'");
          }
        }
      }
      if (obj0.has("controller"))
      {
        obj1.defaultController = this.supply(this.resolve(obj0.getString("controller"), (Class) ClassLiteral<FlyingAI>.Value));
        obj0.remove("controller");
      }
      if (obj0.has("waves"))
      {
        JsonValue jsonData = obj0.remove("waves");
        SpawnGroup[] spawnGroupArray1 = (SpawnGroup[]) this.parser.readValue((Class) ClassLiteral<SpawnGroup[]>.Value, jsonData);
        SpawnGroup[] spawnGroupArray2 = spawnGroupArray1;
        int length = spawnGroupArray2.Length;
        for (int index = 0; index < length; ++index)
          spawnGroupArray2[index].type = obj1;
        Vars.waves.get().addAll((object[]) spawnGroupArray1);
      }
      this.readFields((object) obj1, obj0, true);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 106, 127, 6, 127, 9, 127, 160, 101, 127, 8, 127, 8, 159, 8, 104, 152, 255, 3, 60, 226, 71, 117, 159, 42, 101, 172, 137, 106, 208, 127, 0, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00240([In] JsonValue obj0, [In] Block obj1)
    {
      if (obj0.has("consumes") && obj0.get("consumes").isObject())
      {
        JsonValue.JsonIterator jsonIterator = obj0.get("consumes").iterator();
        while (((Iterator) jsonIterator).hasNext())
        {
          JsonValue jsonData = (JsonValue) ((Iterator) jsonIterator).next();
          string name = jsonData.name;
          int num = -1;
          switch (String.instancehelper_hashCode(name))
          {
            case -1102567108:
              if (String.instancehelper_equals(name, (object) "liquid"))
              {
                num = 2;
                break;
              }
              break;
            case -163731196:
              if (String.instancehelper_equals(name, (object) "powerBuffered"))
              {
                num = 4;
                break;
              }
              break;
            case 3242771:
              if (String.instancehelper_equals(name, (object) "item"))
              {
                num = 0;
                break;
              }
              break;
            case 100526016:
              if (String.instancehelper_equals(name, (object) "items"))
              {
                num = 1;
                break;
              }
              break;
            case 106858757:
              if (String.instancehelper_equals(name, (object) "power"))
              {
                num = 3;
                break;
              }
              break;
          }
          switch (num)
          {
            case 0:
              obj1.__\u003C\u003Econsumes.item((Item) this.find(ContentType.__\u003C\u003Eitem, jsonData.asString()));
              continue;
            case 1:
              obj1.__\u003C\u003Econsumes.add((Consume) this.parser.readValue((Class) ClassLiteral<ConsumeItems>.Value, jsonData));
              continue;
            case 2:
              obj1.__\u003C\u003Econsumes.add((Consume) this.parser.readValue((Class) ClassLiteral<ConsumeLiquid>.Value, jsonData));
              continue;
            case 3:
              if (jsonData.isNumber())
              {
                obj1.__\u003C\u003Econsumes.power(jsonData.asFloat());
                continue;
              }
              obj1.__\u003C\u003Econsumes.add((Consume) this.parser.readValue((Class) ClassLiteral<ConsumePower>.Value, jsonData));
              continue;
            case 4:
              obj1.__\u003C\u003Econsumes.powerBuffered(jsonData.asFloat());
              continue;
            default:
              string str = new StringBuilder().append("Unknown consumption type: '").append(jsonData.name).append("' for block '").append(obj1.__\u003C\u003Ename).append("'.").toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str);
          }
        }
        obj0.remove("consumes");
      }
      this.readFields((object) obj1, obj0, true);
      if (obj1.size > 16)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("Blocks cannot be larger than 16");
      }
      if (!obj0.has("requirements") || !object.ReferenceEquals((object) obj1.buildVisibility, (object) BuildVisibility.__\u003C\u003Ehidden))
        return;
      obj1.buildVisibility = BuildVisibility.__\u003C\u003Eshown;
    }

    [LineNumberTable(new byte[] {159, 186, 136, 107, 127, 10, 139, 236, 160, 93, 107, 107, 235, 69, 236, 115, 255, 69, 160, 126, 127, 2, 230, 159, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ContentParser()
    {
      ContentParser contentParser = this;
      this.contentTypes = new ObjectMap();
      this.implicitNullable = ObjectSet.with((object[]) new Class[3]
      {
        (Class) ClassLiteral<TextureRegion>.Value,
        (Class) ClassLiteral<TextureRegion[]>.Value,
        (Class) ClassLiteral<TextureRegion[][]>.Value
      });
      this.sounds = new ObjectMap();
      this.classParsers = (ObjectMap) new ContentParser.\u0031(this);
      this.reads = new Seq();
      this.postreads = new Seq();
      this.toBeParsed = new ObjectSet();
      this.parser = (Json) new ContentParser.\u0032(this);
      this.parsers = ObjectMap.of((object) ContentType.__\u003C\u003Eblock, (object) new ContentParser.__\u003C\u003EAnon0(this), (object) ContentType.__\u003C\u003Eunit, (object) new ContentParser.__\u003C\u003EAnon1(this), (object) ContentType.__\u003C\u003Eweather, (object) new ContentParser.__\u003C\u003EAnon2(this), (object) ContentType.__\u003C\u003Eitem, (object) this.parser(ContentType.__\u003C\u003Eitem, (Func) new ContentParser.__\u003C\u003EAnon3()), (object) ContentType.__\u003C\u003Eliquid, (object) this.parser(ContentType.__\u003C\u003Eliquid, (Func) new ContentParser.__\u003C\u003EAnon4()));
    }

    [LineNumberTable(new byte[] {161, 76, 118, 118, 108, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finishParsing()
    {
      this.reads.each((Cons) new ContentParser.__\u003C\u003EAnon12(this));
      this.postreads.each((Cons) new ContentParser.__\u003C\u003EAnon12(this));
      this.reads.clear();
      this.postreads.clear();
      this.toBeParsed.clear();
    }

    [Throws(new string[] {"java.lang.Exception"})]
    [LineNumberTable(new byte[] {161, 92, 109, 198, 115, 191, 21, 159, 3, 111, 191, 17, 103, 113, 127, 2, 110, 142, 100, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Content parse(
      Mods.LoadedMod mod,
      string name,
      string json,
      Fi file,
      ContentType type)
    {
      if (this.contentTypes.isEmpty())
        this.init();
      if (String.instancehelper_equals(file.extension(), (object) nameof (json)))
      {
        string str = json;
        object obj1 = (object) "\\#";
        object obj2 = (object) "#";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence2 = charSequence1;
        object obj3 = obj1;
        charSequence1.__\u003Cref\u003E = (__Null) obj3;
        CharSequence charSequence3 = charSequence1;
        json = String.instancehelper_replace(str, charSequence2, charSequence3);
      }
      JsonValue jsonValue = (JsonValue) this.parser.fromJson((Class) null, Jval.read(json).toString(Jval.Jformat.__\u003C\u003Eplain));
      if (!this.parsers.containsKey((object) type))
      {
        string message = new StringBuilder().append("No parsers for content type '").append((object) type).append("'").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SerializationException(message);
      }
      this.currentMod = mod;
      int num = this.locate(type, name) == null ? 0 : 1;
      Content content = ((ContentParser.TypeParser) this.parsers.get((object) type)).parse(mod.__\u003C\u003Ename, name, jsonValue);
      content.minfo.sourceFile = file;
      this.toBeParsed.add((object) content);
      if (num == 0)
        content.minfo.mod = mod;
      return content;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (ContentParser.__\u003CcallerID\u003E == null)
        ContentParser.__\u003CcallerID\u003E = (CallerID) new ContentParser.__\u003CCallerID\u003E();
      return ContentParser.__\u003CcallerID\u003E;
    }

    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<*>;Lmindustry/mod/ContentParser$FieldParser;>;")]
    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0031 : ObjectMap
    {
      [Modifiers]
      internal ContentParser this\u00240;

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {2, 104, 146, 127, 2, 108, 114, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00240([In] Class obj0, [In] JsonValue obj1)
      {
        if (obj1.isString())
          return this.this\u00240.field((Class) ClassLiteral<Fx>.Value, obj1);
        Class @class = this.this\u00240.resolve(obj1.getString("type", ""), (Class) ClassLiteral<ParticleEffect>.Value);
        obj1.remove("type");
        Effect effect = (Effect) this.this\u00240.make(@class);
        this.this\u00240.readFields((object) effect, obj1);
        return (object) effect;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(61)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00241([In] Class obj0, [In] JsonValue obj1) => this.this\u00240.field((Class) ClassLiteral<Interp>.Value, obj1);

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {13, 114, 99, 130, 103, 109, 135})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00242([In] Class obj0, [In] JsonValue obj1)
      {
        object obj = this.this\u00240.fieldOpt((Class) ClassLiteral<Loadouts>.Value, obj1);
        if (obj != null)
          return obj;
        string schematic = obj1.asString();
        return String.instancehelper_startsWith(schematic, "bXNjaA") ? (object) Schematics.readBase64(schematic) : (object) Schematics.read(Vars.tree.get(new StringBuilder().append("schematics/").append(schematic).append(".").append("msch").toString()));
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {26, 114, 99, 130, 127, 32, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00243([In] Class obj0, [In] JsonValue obj1)
      {
        object obj = this.this\u00240.fieldOpt((Class) ClassLiteral<StatusEffects>.Value, obj1);
        if (obj != null)
          return obj;
        StatusEffect statusEffect = new StatusEffect(new StringBuilder().append(this.this\u00240.currentMod.__\u003C\u003Ename).append("-").append(obj1.getString("name")).toString());
        this.this\u00240.readFields((object) statusEffect, obj1);
        return (object) statusEffect;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(84)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static object lambda\u0024new\u00244([In] Class obj0, [In] JsonValue obj1) => (object) Color.valueOf(obj1.asString());

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {36, 104, 146, 127, 2, 108, 114, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00245([In] Class obj0, [In] JsonValue obj1)
      {
        if (obj1.isString())
          return this.this\u00240.field((Class) ClassLiteral<Bullets>.Value, obj1);
        Class @class = this.this\u00240.resolve(obj1.getString("type", ""), (Class) ClassLiteral<BasicBulletType>.Value);
        obj1.remove("type");
        BulletType bulletType = (BulletType) this.this\u00240.make(@class);
        this.this\u00240.readFields((object) bulletType, obj1);
        return (object) bulletType;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {46, 136, 157, 127, 2, 108, 114, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00246([In] Class obj0, [In] JsonValue obj1)
      {
        if (obj1.isString())
          return this.this\u00240.make(this.this\u00240.resolve(obj1.asString()));
        Class @class = this.this\u00240.resolve(obj1.getString("type", ""), (Class) ClassLiteral<DrawBlock>.Value);
        obj1.remove("type");
        DrawBlock drawBlock = (DrawBlock) this.this\u00240.make(@class);
        this.this\u00240.readFields((object) drawBlock, obj1);
        return (object) drawBlock;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {57, 127, 6, 141, 127, 1, 159, 67, 127, 26, 102, 119, 112, 115})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00247([In] Class obj0, [In] JsonValue obj1)
      {
        if (this.this\u00240.fieldOpt((Class) ClassLiteral<Sounds>.Value, obj1) != null)
          return this.this\u00240.fieldOpt((Class) ClassLiteral<Sounds>.Value, obj1);
        if (Vars.headless)
          return (object) new Sound();
        string str = new StringBuilder().append("sounds/").append(obj1.asString()).toString();
        string fileName = !Vars.tree.get(new StringBuilder().append(str).append(".ogg").toString()).exists() ? new StringBuilder().append(str).append(".mp3").toString() : new StringBuilder().append(str).append(".ogg").toString();
        if (this.this\u00240.sounds.containsKey((object) fileName))
          return (object) ((SoundLoader.SoundParameter) ((AssetDescriptor) this.this\u00240.sounds.get((object) fileName)).__\u003C\u003Eparams).sound;
        Sound sound = new Sound();
        AssetDescriptor assetDescriptor = Core.assets.load(fileName, (Class) ClassLiteral<Sound>.Value, (AssetLoaderParameters) new SoundLoader.SoundParameter(sound));
        assetDescriptor.errored = (Cons) new ContentParser.\u0031.__\u003C\u003EAnon11();
        this.this\u00240.sounds.put((object) fileName, (object) assetDescriptor);
        return (object) sound;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {71, 127, 2, 108, 114, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00248([In] Class obj0, [In] JsonValue obj1)
      {
        Class @class = this.this\u00240.resolve(obj1.getString("type", ""), (Class) ClassLiteral<Objectives.SectorComplete>.Value);
        obj1.remove("type");
        Objectives.Objective objective = (Objectives.Objective) this.this\u00240.make(@class);
        this.this\u00240.readFields((object) objective, obj1);
        return (object) objective;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {78, 124, 108, 114, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u00249([In] Class obj0, [In] JsonValue obj1)
      {
        Class @class = this.this\u00240.resolve(obj1.getString("type", ""));
        obj1.remove("type");
        Ability ability = (Ability) this.this\u00240.make(@class);
        this.this\u00240.readFields((object) ability, obj1);
        return (object) ability;
      }

      [Throws(new string[] {"java.lang.Exception"})]
      [Modifiers]
      [LineNumberTable(new byte[] {85, 102, 109, 127, 27})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object lambda\u0024new\u002410([In] Class obj0, [In] JsonValue obj1)
      {
        Weapon weapon = new Weapon();
        this.this\u00240.readFields((object) weapon, obj1);
        weapon.name = new StringBuilder().append(this.this\u00240.currentMod.__\u003C\u003Ename).append("-").append(weapon.name).toString();
        return (object) weapon;
      }

      [LineNumberTable(new byte[] {0, 111, 247, 74, 119, 247, 77, 247, 73, 118, 247, 74, 247, 75, 247, 78, 247, 71, 247, 71, 247, 70})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ContentParser obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        ContentParser.\u0031 obj = this;
        this.put((object) ClassLiteral<Effect>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon0(this));
        this.put((object) ClassLiteral<Interp>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon1(this));
        this.put((object) ClassLiteral<Schematic>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon2(this));
        this.put((object) ClassLiteral<StatusEffect>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon3(this));
        this.put((object) ClassLiteral<Color>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon4());
        this.put((object) ClassLiteral<BulletType>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon5(this));
        this.put((object) ClassLiteral<DrawBlock>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon6(this));
        this.put((object) ClassLiteral<Sound>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon7(this));
        this.put((object) ClassLiteral<Objectives.Objective>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon8(this));
        this.put((object) ClassLiteral<Ability>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon9(this));
        this.put((object) ClassLiteral<Weapon>.Value, (object) new ContentParser.\u0031.__\u003C\u003EAnon10(this));
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon0([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00240(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon1([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00241(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon2 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon2([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00242(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon3 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon3([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00243(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon4 : ContentParser.FieldParser
      {
        internal __\u003C\u003EAnon4()
        {
        }

        public object parse([In] Class obj0, [In] JsonValue obj1) => ContentParser.\u0031.lambda\u0024new\u00244(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon5 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon5([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00245(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon6 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon6([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00246(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon7 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon7([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00247(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon8 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon8([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00248(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon9 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon9([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u00249(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon10 : ContentParser.FieldParser
      {
        private readonly ContentParser.\u0031 arg\u00241;

        internal __\u003C\u003EAnon10([In] ContentParser.\u0031 obj0) => this.arg\u00241 = obj0;

        public object parse([In] Class obj0, [In] JsonValue obj1) => this.arg\u00241.lambda\u0024new\u002410(obj0, obj1);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon11 : Cons
      {
        internal __\u003C\u003EAnon11()
        {
        }

        public void get([In] object obj0) => Throwable.instancehelper_printStackTrace((Exception) obj0);
      }
    }

    [EnclosingMethod(null, null, null)]
    [SpecialName]
    internal class \u0032 : Json
    {
      [Modifiers]
      internal ContentParser this\u00240;

      [LineNumberTable(150)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] ContentParser obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/util/serialization/JsonValue;Ljava/lang/Class;)TT;")]
      [LineNumberTable(new byte[] {109, 102, 147, 127, 25, 97, 236, 69, 127, 30, 146, 223, 39, 127, 17, 114, 109, 127, 39, 109, 223, 39, 112, 127, 4, 127, 32, 127, 11, 103, 148, 103, 223, 80})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private object internalRead([In] Class obj0, [In] Class obj1, [In] JsonValue obj2, [In] Class obj3)
      {
        if (obj0 != null)
        {
          if (this.this\u00240.classParsers.containsKey((object) obj0))
          {
            object obj;
            Exception exception1;
            try
            {
              obj = ((ContentParser.FieldParser) this.this\u00240.classParsers.get((object) obj0)).parse(obj0, obj2);
            }
            catch (Exception ex)
            {
              M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              if (m0 == null)
              {
                throw;
              }
              else
              {
                exception1 = (Exception) m0;
                goto label_7;
              }
            }
            return obj;
label_7:
            Exception exception2 = exception1;
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException((Exception) exception2);
          }
          CharSequence charSequence1;
          if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<ItemStack>.Value) && obj2.isString())
          {
            string str = obj2.asString();
            object obj = (object) "/";
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            if (String.instancehelper_contains(str, charSequence2))
            {
              string[] strArray = String.instancehelper_split(obj2.asString(), "/");
              return this.fromJson((Class) ClassLiteral<ItemStack>.Value, new StringBuilder().append("{item: ").append(strArray[0]).append(", amount: ").append(strArray[1]).append("}").toString());
            }
          }
          if (obj2.isString())
          {
            string str = obj2.asString();
            object obj = (object) "/";
            charSequence1.__\u003Cref\u003E = (__Null) obj;
            CharSequence charSequence2 = charSequence1;
            if (String.instancehelper_contains(str, charSequence2))
            {
              string[] strArray = String.instancehelper_split(obj2.asString(), "/");
              if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<LiquidStack>.Value))
                return this.fromJson((Class) ClassLiteral<LiquidStack>.Value, new StringBuilder().append("{liquid: ").append(strArray[0]).append(", amount: ").append(strArray[1]).append("}").toString());
              if (object.ReferenceEquals((object) obj0, (object) ClassLiteral<ConsumeLiquid>.Value))
                return this.fromJson((Class) ClassLiteral<ConsumeLiquid>.Value, new StringBuilder().append("{liquid: ").append(strArray[0]).append(", amount: ").append(strArray[1]).append("}").toString());
            }
          }
          if (((Class) ClassLiteral<Content>.Value).isAssignableFrom(obj0))
          {
            ContentType type = (ContentType) this.this\u00240.contentTypes.getThrow((object) obj0, (Prov) new ContentParser.\u0032.__\u003C\u003EAnon0(obj0));
            string str1 = this.this\u00240.currentMod == null ? "" : new StringBuilder().append(this.this\u00240.currentMod.__\u003C\u003Ename).append("-").toString();
            MappableContent byName1 = Vars.content.getByName(type, new StringBuilder().append(str1).append(obj2.asString()).toString());
            if (byName1 != null)
              return (object) byName1;
            MappableContent byName2 = Vars.content.getByName(type, obj2.asString());
            if (byName2 != null)
              return (object) byName2;
            string str2 = new StringBuilder().append("\"").append(obj2.name).append("\": No ").append((object) type).append(" found with name '").append(obj2.asString()).append("'.\nMake sure '").append(obj2.asString()).append("' is spelled correctly, and that it really exists!\nThis may also occur because its file failed to parse.").toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException(str2);
          }
        }
        return base.readValue(obj0, obj1, obj2, obj3);
      }

      [Modifiers]
      [LineNumberTable(186)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static RuntimeException lambda\u0024internalRead\u00240([In] Class obj0) => (RuntimeException) new IllegalArgumentException(new StringBuilder().append("No content type for class: ").append(obj0.getSimpleName()).toString());

      [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/util/serialization/JsonValue;Ljava/lang/Class;)TT;")]
      [LineNumberTable(new byte[] {103, 108, 111})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object readValue([In] Class obj0, [In] Class obj1, [In] JsonValue obj2, [In] Class obj3)
      {
        object obj = this.internalRead(obj0, obj1, obj2, obj3);
        if (obj != null)
          this.this\u00240.checkNullFields(obj);
        return obj;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Prov
      {
        private readonly Class arg\u00241;

        internal __\u003C\u003EAnon0([In] Class obj0) => this.arg\u00241 = obj0;

        public object get() => (object) ContentParser.\u0032.lambda\u0024internalRead\u00240(this.arg\u00241);
      }
    }

    [InnerClass]
    internal interface FieldParser
    {
      [Throws(new string[] {"java.lang.Exception"})]
      [Signature("(Ljava/lang/Class<*>;Larc/util/serialization/JsonValue;)Ljava/lang/Object;")]
      object parse([In] Class obj0, [In] JsonValue obj1);
    }

    [InnerClass]
    [Signature("<T:Lmindustry/ctype/Content;>Ljava/lang/Object;")]
    internal interface TypeParser
    {
      [Throws(new string[] {"java.lang.Exception"})]
      [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/util/serialization/JsonValue;)TT;")]
      Content parse([In] string obj0, [In] string obj1, [In] JsonValue obj2);
    }

    internal class UnitReq : Object
    {
      public Block block;
      public ItemStack[] requirements;
      [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
      public UnitType previous;
      public float time;

      [LineNumberTable(new byte[] {162, 118, 136, 172})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal UnitReq()
      {
        ContentParser.UnitReq unitReq = this;
        this.requirements = new ItemStack[0];
        this.time = 600f;
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : ContentParser.TypeParser
    {
      private readonly ContentParser arg\u00241;

      internal __\u003C\u003EAnon0([In] ContentParser obj0) => this.arg\u00241 = obj0;

      public Content parse([In] string obj0, [In] string obj1, [In] JsonValue obj2) => (Content) this.arg\u00241.lambda\u0024new\u00241(obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : ContentParser.TypeParser
    {
      private readonly ContentParser arg\u00241;

      internal __\u003C\u003EAnon1([In] ContentParser obj0) => this.arg\u00241 = obj0;

      public Content parse([In] string obj0, [In] string obj1, [In] JsonValue obj2) => (Content) this.arg\u00241.lambda\u0024new\u00243(obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : ContentParser.TypeParser
    {
      private readonly ContentParser arg\u00241;

      internal __\u003C\u003EAnon2([In] ContentParser obj0) => this.arg\u00241 = obj0;

      public Content parse([In] string obj0, [In] string obj1, [In] JsonValue obj2) => (Content) this.arg\u00241.lambda\u0024new\u00245(obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) new Item((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Func
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public object get([In] object obj0) => (object) new Liquid((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Prov
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get() => (object) UnitEntity.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Prov
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public object get() => (object) MechUnit.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Prov
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public object get() => (object) LegsUnit.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) UnitWaterMove.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Prov
    {
      internal __\u003C\u003EAnon9()
      {
      }

      public object get() => (object) PayloadUnit.create();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : ContentParser.TypeParser
    {
      private readonly ContentParser arg\u00241;
      private readonly ContentType arg\u00242;
      private readonly Func arg\u00243;

      internal __\u003C\u003EAnon10([In] ContentParser obj0, [In] ContentType obj1, [In] Func obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public Content parse([In] string obj0, [In] string obj1, [In] JsonValue obj2) => this.arg\u00241.lambda\u0024parser\u00247(this.arg\u00242, this.arg\u00243, obj0, obj1, obj2);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Runnable
    {
      private readonly ContentParser arg\u00241;
      private readonly Mods.LoadedMod arg\u00242;
      private readonly Content arg\u00243;
      private readonly Runnable arg\u00244;

      internal __\u003C\u003EAnon11(
        [In] ContentParser obj0,
        [In] Mods.LoadedMod obj1,
        [In] Content obj2,
        [In] Runnable obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024read\u00248(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Cons
    {
      private readonly ContentParser arg\u00241;

      internal __\u003C\u003EAnon12([In] ContentParser obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.attempt((Runnable) obj0);
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Prov
    {
      private readonly Constructor arg\u00241;

      internal __\u003C\u003EAnon14([In] Constructor obj0) => this.arg\u00241 = obj0;

      public object get() => ContentParser.lambda\u0024supply\u00249(this.arg\u00241);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Cons
    {
      private readonly ContentParser arg\u00241;
      private readonly object arg\u00242;

      internal __\u003C\u003EAnon15([In] ContentParser obj0, [In] object obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024checkNullFields\u002410(this.arg\u00242, (Json.FieldMetadata) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Boolf
    {
      private readonly UnlockableContent arg\u00241;

      internal __\u003C\u003EAnon16([In] UnlockableContent obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (ContentParser.lambda\u0024readFields\u002411(this.arg\u00241, (TechTree.TechNode) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly ContentParser arg\u00241;
      private readonly UnlockableContent arg\u00242;
      private readonly Mods.LoadedMod arg\u00243;
      private readonly TechTree.TechNode arg\u00244;
      private readonly string arg\u00245;

      internal __\u003C\u003EAnon17(
        [In] ContentParser obj0,
        [In] UnlockableContent obj1,
        [In] Mods.LoadedMod obj2,
        [In] TechTree.TechNode obj3,
        [In] string obj4)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
        this.arg\u00245 = obj4;
      }

      public void run() => this.arg\u00241.lambda\u0024readFields\u002413(this.arg\u00242, this.arg\u00243, this.arg\u00244, this.arg\u00245);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon18 : Boolf
    {
      private readonly ContentParser arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon18([In] ContentParser obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024readFields\u002412(this.arg\u00242, (TechTree.TechNode) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon19 : Runnable
    {
      private readonly ContentParser arg\u00241;
      private readonly Content arg\u00242;
      private readonly JsonValue arg\u00243;

      internal __\u003C\u003EAnon19([In] ContentParser obj0, [In] Content obj1, [In] JsonValue obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024parser\u00246(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon20 : Runnable
    {
      private readonly ContentParser arg\u00241;
      private readonly Weather arg\u00242;
      private readonly JsonValue arg\u00243;

      internal __\u003C\u003EAnon20([In] ContentParser obj0, [In] Weather obj1, [In] JsonValue obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00244(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon21 : Runnable
    {
      private readonly ContentParser arg\u00241;
      private readonly JsonValue arg\u00242;
      private readonly UnitType arg\u00243;

      internal __\u003C\u003EAnon21([In] ContentParser obj0, [In] JsonValue obj1, [In] UnitType obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon22 : Runnable
    {
      private readonly ContentParser arg\u00241;
      private readonly JsonValue arg\u00242;
      private readonly Block arg\u00243;

      internal __\u003C\u003EAnon22([In] ContentParser obj0, [In] JsonValue obj1, [In] Block obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242, this.arg\u00243);
    }
  }
}
