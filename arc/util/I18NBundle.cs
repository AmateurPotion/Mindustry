// Decompiled with JetBrains decompiler
// Type: arc.util.I18NBundle
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class I18NBundle : Object
  {
    private const string DEFAULT_ENCODING = "UTF-8";
    [Modifiers]
    private static Locale ROOT_LOCALE;
    private static bool simpleFormatter;
    private I18NBundle parent;
    private Locale locale;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;")]
    private ObjectMap properties;
    private TextFormatter formatter;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(463)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string format(string key, params object[] args) => this.formatter.format(this.get(key), args);

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static I18NBundle createBundle(Fi baseFileHandle, Locale locale) => I18NBundle.createBundleImpl(baseFileHandle, locale, "UTF-8");

    [LineNumberTable(new byte[] {161, 106, 108, 132, 123, 110, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void debug(string placeholder)
    {
      ObjectMap.Keys keys1 = this.properties.keys();
      if (keys1 == null)
        return;
      ObjectMap.Keys keys2 = keys1.iterator();
      while (((Iterator) keys2).hasNext())
        this.properties.put((object) (string) ((Iterator) keys2).next(), (object) placeholder);
    }

    [LineNumberTable(412)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string get(string key, string def) => this.has(key) ? this.get(key) : def;

    [LineNumberTable(416)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getOrNull(string key) => this.has(key) ? this.get(key) : (string) null;

    [LineNumberTable(new byte[] {161, 30, 114, 99, 117, 99, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public string get(string key)
    {
      string str = (string) this.properties.get((object) key);
      if (str == null)
      {
        if (this.parent != null)
          str = this.parent.get(key);
        if (str == null)
          return new StringBuilder().append("???").append(key).append("???").toString();
      }
      return str;
    }

    [LineNumberTable(468)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string formatFloat(string key, float value, int places) => this.formatter.format(this.get(key), (object) Strings.@fixed(value, places));

    [LineNumberTable(new byte[] {161, 73, 110, 162, 104, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool has(string key)
    {
      if (this.properties.containsKey((object) key))
        return true;
      return this.parent != null && this.parent.has(key);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual I18NBundle getParent() => this.parent;

    [Signature("()Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ObjectMap getProperties() => this.properties;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Locale getLocale() => this.locale;

    [LineNumberTable(new byte[] {27, 102, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static I18NBundle createEmptyBundle() => new I18NBundle()
    {
      locale = I18NBundle.ROOT_LOCALE,
      properties = new ObjectMap()
    };

    [LineNumberTable(130)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static I18NBundle createBundle(
      Fi baseFileHandle,
      Locale locale,
      string encoding)
    {
      return I18NBundle.createBundleImpl(baseFileHandle, locale, encoding);
    }

    [LineNumberTable(46)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public I18NBundle()
    {
    }

    [LineNumberTable(new byte[] {84, 180, 98, 162, 167, 171, 99, 104, 142, 142, 130, 153, 130, 131, 226, 69, 135, 134, 99, 131, 223, 64, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static I18NBundle createBundleImpl([In] Fi obj0, [In] Locale obj1, [In] string obj2)
    {
      if (obj0 == null || obj1 == null || obj2 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new NullPointerException();
      }
      I18NBundle i18Nbundle1 = (I18NBundle) null;
      Locale locale1 = obj1;
      I18NBundle i18Nbundle2;
      do
      {
        List candidateLocales = I18NBundle.getCandidateLocales(locale1);
        i18Nbundle2 = I18NBundle.loadBundleChain(obj0, obj2, candidateLocales, 0, i18Nbundle1);
        if (i18Nbundle2 != null)
        {
          Locale locale2 = i18Nbundle2.locale;
          if (locale2.equals((object) I18NBundle.ROOT_LOCALE) && !locale2.equals((object) obj1) && (candidateLocales.size() != 1 || !locale2.equals(candidateLocales.get(0))))
          {
            if (i18Nbundle1 == null)
              i18Nbundle1 = i18Nbundle2;
          }
          else
            break;
        }
        locale1 = I18NBundle.getFallbackLocale(locale1);
      }
      while (locale1 != null);
      if (i18Nbundle2 == null)
      {
        if (i18Nbundle1 == null)
        {
          string str1 = new StringBuilder().append("Can't find bundle for base file handle ").append(obj0.path()).append(", locale ").append((object) obj1).toString();
          string str2 = new StringBuilder().append((object) obj0).append("_").append((object) obj1).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new MissingResourceException(str1, str2, "");
        }
        i18Nbundle2 = i18Nbundle1;
      }
      return i18Nbundle2;
    }

    [Signature("(Ljava/util/Locale;)Ljava/util/List<Ljava/util/Locale;>;")]
    [LineNumberTable(new byte[] {160, 119, 103, 103, 135, 103, 105, 136, 105, 153, 105, 152, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static List getCandidateLocales([In] Locale obj0)
    {
      string language = obj0.getLanguage();
      string country = obj0.getCountry();
      string variant = obj0.getVariant();
      ArrayList arrayList = new ArrayList(4);
      if (String.instancehelper_length(variant) > 0)
        ((List) arrayList).add((object) obj0);
      if (String.instancehelper_length(country) > 0)
        ((List) arrayList).add(!((List) arrayList).isEmpty() ? (object) new Locale(language, country) : (object) obj0);
      if (String.instancehelper_length(language) > 0)
        ((List) arrayList).add(!((List) arrayList).isEmpty() ? (object) new Locale(language) : (object) obj0);
      ((List) arrayList).add((object) I18NBundle.ROOT_LOCALE);
      return (List) arrayList;
    }

    [Signature("(Larc/files/Fi;Ljava/lang/String;Ljava/util/List<Ljava/util/Locale;>;ILarc/util/I18NBundle;)Larc/util/I18NBundle;")]
    [LineNumberTable(new byte[] {160, 158, 109, 98, 139, 112, 113, 195, 105, 99, 103, 162})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static I18NBundle loadBundleChain(
      [In] Fi obj0,
      [In] string obj1,
      [In] List obj2,
      [In] int obj3,
      [In] I18NBundle obj4)
    {
      Locale locale = (Locale) obj2.get(obj3);
      I18NBundle i18Nbundle1 = (I18NBundle) null;
      if (obj3 != obj2.size() - 1)
        i18Nbundle1 = I18NBundle.loadBundleChain(obj0, obj1, obj2, obj3 + 1, obj4);
      else if (obj4 != null && locale.equals((object) I18NBundle.ROOT_LOCALE))
        return obj4;
      I18NBundle i18Nbundle2 = I18NBundle.loadBundle(obj0, obj1, locale);
      if (i18Nbundle2 == null)
        return i18Nbundle1;
      i18Nbundle2.parent = i18Nbundle1;
      return i18Nbundle2;
    }

    [LineNumberTable(new byte[] {160, 152, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Locale getFallbackLocale([In] Locale obj0)
    {
      Locale locale = Locale.getDefault();
      return obj0.equals((object) locale) ? (Locale) null : locale;
    }

    [LineNumberTable(new byte[] {160, 179, 98, 130, 104, 136, 166, 104, 171, 102, 35, 98, 98, 99, 167})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static I18NBundle loadBundle([In] Fi obj0, [In] string obj1, [In] Locale obj2)
    {
      I18NBundle i18Nbundle = (I18NBundle) null;
      Reader reader = (Reader) null;
      try
      {
        Fi fileHandle = I18NBundle.toFileHandle(obj0, obj2);
        if (I18NBundle.checkFileExistence(fileHandle))
        {
          i18Nbundle = new I18NBundle();
          reader = fileHandle.reader(obj1);
          i18Nbundle.load(reader);
        }
      }
      finally
      {
        Streams.close((Closeable) reader);
      }
      i18Nbundle?.setLocale(obj2);
      return i18Nbundle;
    }

    [LineNumberTable(new byte[] {160, 230, 108, 112, 103, 103, 103, 109, 109, 141, 111, 105, 100, 127, 5, 100, 151, 200})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Fi toFileHandle([In] Fi obj0, [In] Locale obj1)
    {
      StringBuilder stringBuilder = new StringBuilder(obj0.name());
      if (!obj1.equals((object) I18NBundle.ROOT_LOCALE))
      {
        string language = obj1.getLanguage();
        string country = obj1.getCountry();
        string variant = obj1.getVariant();
        int num1 = String.instancehelper_equals("", (object) language) ? 1 : 0;
        int num2 = String.instancehelper_equals("", (object) country) ? 1 : 0;
        int num3 = String.instancehelper_equals("", (object) variant) ? 1 : 0;
        if (num1 == 0 || num2 == 0 || num3 == 0)
        {
          stringBuilder.append('_');
          if (num3 == 0)
            stringBuilder.append(language).append('_').append(country).append('_').append(variant);
          else if (num2 == 0)
            stringBuilder.append(language).append('_').append(country);
          else
            stringBuilder.append(language);
        }
      }
      return obj0.sibling(stringBuilder.append(".properties").toString());
    }

    [LineNumberTable(new byte[] {160, 204, 107, 122, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool checkFileExistence([In] Fi obj0)
    {
      int num;
      try
      {
        obj0.read().close();
        num = 1;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_4;
      }
      return num != 0;
label_4:
      return false;
    }

    [LineNumberTable(new byte[] {161, 2, 107, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void load([In] Reader obj0)
    {
      this.properties = new ObjectMap();
      PropertiesUtils.load(this.properties, obj0);
    }

    [LineNumberTable(new byte[] {161, 19, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void setLocale([In] Locale obj0)
    {
      this.locale = obj0;
      this.formatter = new TextFormatter(obj0, !I18NBundle.simpleFormatter);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool getSimpleFormatter() => I18NBundle.simpleFormatter;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setSimpleFormatter(bool enabled) => I18NBundle.simpleFormatter = enabled;

    [LineNumberTable(91)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static I18NBundle createBundle(Fi baseFileHandle) => I18NBundle.createBundleImpl(baseFileHandle, Locale.getDefault(), "UTF-8");

    [LineNumberTable(116)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static I18NBundle createBundle(Fi baseFileHandle, string encoding) => I18NBundle.createBundleImpl(baseFileHandle, Locale.getDefault(), encoding);

    [LineNumberTable(new byte[] {161, 50, 104, 99, 159, 28})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getNotNull(string key)
    {
      string orNull = this.getOrNull(key);
      if (orNull == null)
      {
        string str1 = new StringBuilder().append("No key with name \"").append(key).append("\" found!").toString();
        string name = Object.instancehelper_getClass((object) this).getName();
        string str2 = key;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new MissingResourceException(str1, name, str2);
      }
      return orNull;
    }

    [Signature("()Ljava/lang/Iterable<Ljava/lang/String;>;")]
    [LineNumberTable(429)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Iterable getKeys() => (Iterable) this.properties.keys();

    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProperties(ObjectMap properties) => this.properties = properties;

    [LineNumberTable(new byte[] {159, 130, 109, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static I18NBundle()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.I18NBundle"))
        return;
      I18NBundle.ROOT_LOCALE = new Locale("", "", "");
      I18NBundle.simpleFormatter = false;
    }
  }
}
