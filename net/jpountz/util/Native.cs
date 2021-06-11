// Decompiled with JetBrains decompiler
// Type: net.jpountz.util.Native
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.util
{
  [Signature("Ljava/lang/Enum<Lnet/jpountz/util/Native;>;")]
  [Modifiers]
  [Serializable]
  public sealed class Native : Enum
  {
    private static bool loaded;
    [Modifiers]
    private static Native[] \u0024VALUES;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isLoaded()
    {
      lock ((object) ClassLiteral<Native>.Value)
        return Native.loaded;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 125, 172, 103, 229, 69, 111, 123, 101, 193, 102, 108, 99, 223, 16, 159, 15, 136, 140, 106, 101, 130, 108, 130, 103, 171, 31, 3, 161, 112, 182, 100, 207, 21, 161, 107, 103, 169, 251, 52, 98, 100, 207, 14, 161, 107, 103, 169, 243, 70, 2, 97, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load()
    {
      lock ((object) ClassLiteral<Native>.Value)
      {
        if (Native.loaded)
          return;
        try
        {
          java.lang.System.loadLibrary("lz4-java", Native.__\u003CGetCallerID\u003E());
          Native.loaded = true;
          return;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<UnsatisfiedLinkError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
        string str1 = Native.resourceName();
        InputStream resourceAsStream = ((Class) ClassLiteral<Native>.Value).getResourceAsStream(str1);
        if (resourceAsStream == null)
        {
          string str2 = new StringBuilder().append("Unsupported OS/arch, cannot find ").append(str1).append(". Please try building from source.").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new UnsupportedOperationException(str2);
        }
        File tempFile;
        FileOutputStream fileOutputStream;
        Exception exception1;
        try
        {
          tempFile = File.createTempFile("liblz4-java", new StringBuilder().append(".").append(Native.os().libExtension).toString());
          fileOutputStream = new FileOutputStream(tempFile);
          try
          {
            byte[] numArray = new byte[4096];
            while (true)
            {
              int num = resourceAsStream.read(numArray);
              if (num != -1)
                fileOutputStream.write(numArray, 0, num);
              else
                break;
            }
            try
            {
              fileOutputStream.close();
              fileOutputStream = (FileOutputStream) null;
              goto label_18;
            }
            catch (IOException ex)
            {
            }
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_16;
          }
        }
        catch (IOException ex)
        {
          goto label_17;
        }
        goto label_18;
label_16:
        Exception exception2 = exception1;
        goto label_33;
label_17:
        // ISSUE: variable of the null type
        __Null local = null;
        goto label_48;
label_18:
        Exception exception3;
        try
        {
          try
          {
            java.lang.System.load(tempFile.getAbsolutePath(), Native.__\u003CGetCallerID\u003E());
            Native.loaded = true;
          }
          catch (Exception ex)
          {
            exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_24;
          }
          try
          {
            if (fileOutputStream != null)
            {
              fileOutputStream.close();
              goto label_27;
            }
            else
              goto label_27;
          }
          catch (IOException ex)
          {
            goto label_25;
          }
        }
        catch (IOException ex)
        {
          goto label_26;
        }
label_24:
        exception2 = exception3;
        goto label_33;
label_25:
        goto label_27;
label_26:
        local = null;
        goto label_48;
label_27:
        try
        {
          if (tempFile == null || !tempFile.exists())
            return;
          if (!Native.loaded)
          {
            tempFile.delete();
            return;
          }
          tempFile.deleteOnExit();
          return;
        }
        catch (IOException ex)
        {
        }
        local = null;
        goto label_48;
label_33:
        Exception exception4 = exception2;
        Exception exception5;
        try
        {
          exception5 = exception4;
          try
          {
            if (fileOutputStream != null)
            {
              fileOutputStream.close();
              goto label_41;
            }
            else
              goto label_41;
          }
          catch (IOException ex)
          {
          }
        }
        catch (IOException ex)
        {
          goto label_40;
        }
        goto label_41;
label_40:
        local = null;
        goto label_48;
label_41:
        try
        {
          if (tempFile != null && tempFile.exists())
          {
            if (!Native.loaded)
              tempFile.delete();
            else
              tempFile.deleteOnExit();
          }
          throw Throwable.__\u003Cunmap\u003E(exception5);
        }
        catch (IOException ex)
        {
        }
        local = null;
label_48:
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ExceptionInInitializerError("Cannot unpack liblz4-java");
      }
    }

    [LineNumberTable(new byte[] {159, 184, 107, 125, 102, 125, 102, 125, 102, 127, 27, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Native.OS os()
    {
      string property = java.lang.System.getProperty("os.name");
      string str1 = property;
      object obj1 = (object) "Linux";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      if (String.instancehelper_contains(str1, charSequence2))
        return Native.OS.LINUX;
      string str2 = property;
      object obj2 = (object) "Mac";
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence3 = charSequence1;
      if (String.instancehelper_contains(str2, charSequence3))
        return Native.OS.MAC;
      string str3 = property;
      object obj3 = (object) "Windows";
      charSequence1.__\u003Cref\u003E = (__Null) obj3;
      CharSequence charSequence4 = charSequence1;
      if (String.instancehelper_contains(str3, charSequence4))
        return Native.OS.WINDOWS;
      string str4 = property;
      object obj4 = (object) "Solaris";
      charSequence1.__\u003Cref\u003E = (__Null) obj4;
      CharSequence charSequence5 = charSequence1;
      if (!String.instancehelper_contains(str4, charSequence5))
      {
        string str5 = property;
        object obj5 = (object) "SunOS";
        charSequence1.__\u003Cref\u003E = (__Null) obj5;
        CharSequence charSequence6 = charSequence1;
        if (!String.instancehelper_contains(str5, charSequence6))
        {
          string str6 = new StringBuilder().append("Unsupported operating system: ").append(property).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new UnsupportedOperationException(str6);
        }
      }
      return Native.OS.SOLARIS;
    }

    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string arch() => java.lang.System.getProperty("os.arch");

    [LineNumberTable(new byte[] {8, 102, 153})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string resourceName()
    {
      Native.OS os = Native.os();
      string str = String.instancehelper_replace(((Class) ClassLiteral<Native>.Value).getPackage().getName(), '.', '/');
      return new StringBuilder().append("/").append(str).append("/").append(os.name).append("/").append(Native.arch()).append("/liblz4-java.").append(os.libExtension).toString();
    }

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Native[] values() => (Native[]) Native.\u0024VALUES.Clone();

    [LineNumberTable(23)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Native valueOf(string name) => (Native) Enum.valueOf((Class) ClassLiteral<Native>.Value, name);

    [Signature("()V")]
    [LineNumberTable(new byte[] {159, 165, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Native([In] string obj0, [In] int obj1)
      : base(obj0, obj1)
    {
      GC.KeepAlive((object) this);
    }

    [LineNumberTable(new byte[] {159, 137, 173, 235, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Native()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.util.Native"))
        return;
      Native.\u0024VALUES = new Native[0];
      Native.loaded = false;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Native.__\u003CcallerID\u003E == null)
        Native.__\u003CcallerID\u003E = (CallerID) new Native.__\u003CCallerID\u003E();
      return Native.__\u003CcallerID\u003E;
    }

    [HideFromJava]
    [Serializable]
    public enum __Enum
    {
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lnet/jpountz/util/Native$OS;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class OS : Enum
    {
      [Modifiers]
      public static Native.OS WINDOWS;
      [Modifiers]
      public static Native.OS LINUX;
      [Modifiers]
      public static Native.OS MAC;
      [Modifiers]
      public static Native.OS SOLARIS;
      [Modifiers]
      public string name;
      [Modifiers]
      public string libExtension;
      [Modifiers]
      private static Native.OS[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("(Ljava/lang/String;Ljava/lang/String;)V")]
      [LineNumberTable(new byte[] {159, 173, 106, 103, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private OS([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3)
        : base(obj0, obj1)
      {
        Native.OS os = this;
        this.name = obj2;
        this.libExtension = obj3;
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Native.OS[] values() => (Native.OS[]) Native.OS.\u0024VALUES.Clone();

      [LineNumberTable(26)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Native.OS valueOf([In] string obj0) => (Native.OS) Enum.valueOf((Class) ClassLiteral<Native.OS>.Value, obj0);

      [LineNumberTable(new byte[] {159, 135, 77, 31, 73})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static OS()
      {
        if (ByteCodeHelper.isAlreadyInited("net.jpountz.util.Native$OS"))
          return;
        Native.OS.WINDOWS = new Native.OS(nameof (WINDOWS), 0, "win32", "so");
        Native.OS.LINUX = new Native.OS(nameof (LINUX), 1, "linux", "so");
        Native.OS.MAC = new Native.OS(nameof (MAC), 2, "darwin", "dylib");
        Native.OS.SOLARIS = new Native.OS(nameof (SOLARIS), 3, "solaris", "so");
        Native.OS.\u0024VALUES = new Native.OS[4]
        {
          Native.OS.WINDOWS,
          Native.OS.LINUX,
          Native.OS.MAC,
          Native.OS.SOLARIS
        };
      }
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
