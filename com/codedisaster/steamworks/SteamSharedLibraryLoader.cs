// Decompiled with JetBrains decompiler
// Type: com.codedisaster.steamworks.SteamSharedLibraryLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.codedisaster.steamworks
{
  internal class SteamSharedLibraryLoader : Object
  {
    [Modifiers]
    private static SteamSharedLibraryLoader.PLATFORM OS;
    [Modifiers]
    private static bool IS_64_BIT;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"com.codedisaster.steamworks.SteamException"})]
    [LineNumberTable(new byte[] {159, 183, 98, 191, 2, 136, 124, 97, 98, 99, 138, 227, 53, 233, 81, 115, 63, 2, 184, 97, 98, 99, 138, 195})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void loadLibrary(params string[] _param0)
    {
      Exception exception1 = (Exception) null;
      File[] locations = SteamSharedLibraryLoader.extractLocations("steamworks4j_1.0-Anuken", "out");
      int length1 = locations.Length;
      for (int index = 0; index < length1; ++index)
      {
        File file = locations[index];
        Exception exception2;
        try
        {
          SteamSharedLibraryLoader.canWrite(file);
          SteamSharedLibraryLoader.loadAllLibraries(file, _param0);
          return;
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
        Exception exception3 = exception2;
        if (exception1 != null)
          Throwable.instancehelper_addSuppressed(exception1, exception3);
        else
          exception1 = exception3;
      }
      Exception exception4;
      try
      {
        string[] strArray = _param0;
        int length2 = strArray.Length;
        for (int index = 0; index < length2; ++index)
        {
          string str = strArray[index];
          File.__\u003Cclinit\u003E();
          java.lang.System.load(new File(SteamSharedLibraryLoader.getPlatformLibName(str, true)).getCanonicalPath(), SteamSharedLibraryLoader.__\u003CGetCallerID\u003E());
        }
        return;
      }
      catch (Exception ex)
      {
        exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception5 = exception4;
      if (exception1 != null)
        Throwable.instancehelper_addSuppressed(exception1, exception5);
      else
        exception1 = exception5;
      Exception throwable = exception1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new SteamException(throwable);
    }

    [LineNumberTable(new byte[] {34, 134, 191, 28, 104, 104, 153, 131, 127, 28, 159, 13})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static File[] extractLocations([In] string obj0, [In] string obj1)
    {
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = arrayList1;
      File.__\u003Cclinit\u003E();
      File file1 = new File(new StringBuilder().append(java.lang.System.getProperty("java.io.tmpdir")).append("/").append(obj0).toString(), obj1);
      arrayList2.add((object) file1);
      try
      {
        File tempFile = File.createTempFile(obj0, (string) null);
        if (tempFile.delete())
        {
          arrayList1.add((object) new File(tempFile, obj1));
          goto label_5;
        }
        else
          goto label_5;
      }
      catch (IOException ex)
      {
      }
label_5:
      ArrayList arrayList3 = arrayList1;
      File.__\u003Cclinit\u003E();
      File file2 = new File(new StringBuilder().append(java.lang.System.getProperty("user.home")).append("/.").append(obj0).toString(), obj1);
      arrayList3.add((object) file2);
      ArrayList arrayList4 = arrayList1;
      File.__\u003Cclinit\u003E();
      File file3 = new File(new StringBuilder().append(".tmp/").append(obj0).toString(), obj1);
      arrayList4.add((object) file3);
      return (File[]) arrayList1.toArray((object[]) new File[0]);
    }

    [LineNumberTable(new byte[] {78, 135, 104, 112, 167, 104, 104, 167, 104, 199, 182, 107, 217, 255, 12, 60, 106, 97, 159, 3, 24, 135, 105, 115, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool canWrite([In] File obj0)
    {
      File file;
      int num1;
      Exception exception1;
      try
      {
        File parentFile = obj0.getParentFile();
        if (obj0.exists())
        {
          if (!obj0.canWrite() || !SteamSharedLibraryLoader.canExecute(obj0))
            return false;
        }
        else if (!parentFile.exists() && !parentFile.mkdirs() || !parentFile.isDirectory())
          return false;
        File.__\u003Cclinit\u003E();
        file = new File(parentFile, UUID.randomUUID().toString());
        try
        {
          try
          {
            new FileOutputStream(file).close();
            num1 = SteamSharedLibraryLoader.canExecute(file) ? 1 : 0;
          }
          catch (IOException ex)
          {
            goto label_11;
          }
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_12;
        }
        file.delete();
        goto label_14;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_13;
      }
label_11:
      int num2;
      Exception exception2;
      try
      {
        try
        {
          num2 = 0;
          goto label_21;
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_20;
      }
      Exception exception3 = exception2;
      goto label_25;
label_20:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_29;
label_21:
      try
      {
        file.delete();
        goto label_24;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      local = null;
      goto label_29;
label_24:
      return num2 != 0;
label_12:
      exception3 = exception1;
      goto label_25;
label_13:
      local = null;
      goto label_29;
label_14:
      return num1 != 0;
label_25:
      Exception exception4 = exception3;
      try
      {
        Exception exception5 = exception4;
        file.delete();
        throw Throwable.__\u003Cunmap\u003E(exception5);
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      local = null;
label_29:
      return false;
    }

    [Throws(new string[] {"java.lang.Throwable"})]
    [LineNumberTable(new byte[] {25, 111, 105, 116, 105, 241, 60, 230, 70})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void loadAllLibraries(File _param0, params string[] _param1)
    {
      string[] strArray = _param1;
      int length = strArray.Length;
      for (int index = 0; index < length; ++index)
      {
        string platformLibName = SteamSharedLibraryLoader.getPlatformLibName(strArray[index], true);
        File.__\u003Cclinit\u003E();
        File file = new File(_param0.getParentFile(), platformLibName);
        SteamSharedLibraryLoader.extractLibrary(file, platformLibName);
        java.lang.System.load(file.getCanonicalPath(), SteamSharedLibraryLoader.__\u003CGetCallerID\u003E());
      }
    }

    [LineNumberTable(new byte[] {159, 135, 66, 159, 9, 159, 23, 159, 6, 191, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string getPlatformLibName([In] string obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      switch (SteamSharedLibraryLoader.\u0031.\u0024SwitchMap\u0024com\u0024codedisaster\u0024steamworks\u0024SteamSharedLibraryLoader\u0024PLATFORM[SteamSharedLibraryLoader.OS.ordinal()])
      {
        case 1:
          return new StringBuilder().append(obj0).append(!SteamSharedLibraryLoader.IS_64_BIT || num == 0 ? "" : "64").append(".dll").toString();
        case 2:
          return new StringBuilder().append("lib").append(obj0).append(".so").toString();
        case 3:
          return new StringBuilder().append("lib").append(obj0).append(".dylib").toString();
        default:
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new RuntimeException("Unknown host architecture");
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {52, 159, 6, 102, 105, 139, 105, 103, 106, 122, 255, 13, 71, 102, 63, 34, 102, 63, 2, 102, 249, 49, 255, 2, 78, 102, 244, 56, 255, 15, 71, 102, 63, 20, 102, 59, 102, 57, 102, 37, 102, 230, 56, 162, 104, 170, 102, 35, 98, 132, 159, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void extractLibrary([In] File obj0, [In] string obj1)
    {
      InputStream resourceAsStream = ((Class) ClassLiteral<SteamSharedLibraryLoader>.Value).getResourceAsStream(new StringBuilder().append("/").append(obj1).toString());
      if (resourceAsStream != null)
      {
        FileOutputStream fileOutputStream;
        Exception exception1;
        Exception exception2;
        Exception exception3;
        Exception exception4;
        IOException ioException1;
        // ISSUE: fault handler
        try
        {
          fileOutputStream = new FileOutputStream(obj0);
          exception1 = (Exception) null;
          try
          {
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
            }
            catch (Exception ex)
            {
              exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
              goto label_13;
            }
          }
          catch (Exception ex)
          {
            exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_14;
          }
          if (fileOutputStream != null)
          {
            if (null != null)
            {
              try
              {
                fileOutputStream.close();
                goto label_57;
              }
              catch (Exception ex)
              {
                exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                goto label_15;
              }
            }
            else
              goto label_22;
          }
          else
            goto label_57;
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          goto label_16;
        }
        __fault
        {
          resourceAsStream.close();
        }
label_13:
        Exception exception5 = exception2;
        Exception exception6;
        IOException ioException2;
        // ISSUE: fault handler
        try
        {
          Exception exception7 = exception5;
          try
          {
            exception6 = exception7;
            try
            {
              Exception exception8 = exception6;
              exception1 = exception8;
              throw Throwable.__\u003Cunmap\u003E(exception8);
            }
            catch (Exception ex)
            {
              exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          catch (IOException ex)
          {
            ioException2 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_33;
          }
        }
        __fault
        {
          resourceAsStream.close();
        }
        Exception exception9 = exception6;
        goto label_34;
label_33:
        IOException ioException3 = ioException2;
        goto label_58;
label_14:
        exception9 = exception3;
        goto label_34;
label_15:
        Exception exception10 = exception4;
        IOException ioException4;
        // ISSUE: fault handler
        try
        {
          Exception exception7 = exception10;
          try
          {
            Throwable.instancehelper_addSuppressed((Exception) null, exception7);
            goto label_57;
          }
          catch (IOException ex)
          {
            ioException4 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        __fault
        {
          resourceAsStream.close();
        }
        ioException3 = ioException4;
        goto label_58;
label_16:
        ioException3 = ioException1;
        goto label_58;
label_22:
        IOException ioException5;
        // ISSUE: fault handler
        try
        {
          fileOutputStream.close();
          goto label_57;
        }
        catch (IOException ex)
        {
          ioException5 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        __fault
        {
          resourceAsStream.close();
        }
        ioException3 = ioException5;
        goto label_58;
label_34:
        Exception exception11 = exception9;
        Exception exception12;
        Exception exception13;
        IOException ioException6;
        // ISSUE: fault handler
        try
        {
          exception12 = exception11;
          try
          {
            exception13 = exception12;
            if (fileOutputStream != null)
            {
              if (exception1 != null)
              {
                try
                {
                  fileOutputStream.close();
                  goto label_53;
                }
                catch (Exception ex)
                {
                  exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
                }
              }
              else
                goto label_49;
            }
            else
              goto label_53;
          }
          catch (IOException ex)
          {
            ioException6 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
            goto label_43;
          }
        }
        __fault
        {
          resourceAsStream.close();
        }
        Exception exception14 = exception12;
        IOException ioException7;
        // ISSUE: fault handler
        try
        {
          Exception exception7 = exception14;
          try
          {
            Exception exception8 = exception7;
            Throwable.instancehelper_addSuppressed(exception1, exception8);
            goto label_53;
          }
          catch (IOException ex)
          {
            ioException7 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
          }
        }
        __fault
        {
          resourceAsStream.close();
        }
        ioException3 = ioException7;
        goto label_58;
label_43:
        ioException3 = ioException6;
        goto label_58;
label_49:
        IOException ioException8;
        // ISSUE: fault handler
        try
        {
          fileOutputStream.close();
          goto label_53;
        }
        catch (IOException ex)
        {
          ioException8 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        __fault
        {
          resourceAsStream.close();
        }
        ioException3 = ioException8;
        goto label_58;
label_53:
        IOException ioException9;
        // ISSUE: fault handler
        try
        {
          throw Throwable.__\u003Cunmap\u003E(exception13);
        }
        catch (IOException ex)
        {
          ioException9 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        __fault
        {
          resourceAsStream.close();
        }
        ioException3 = ioException9;
        goto label_58;
label_57:
        resourceAsStream.close();
        return;
label_58:
        IOException ioException10 = ioException3;
        try
        {
          IOException ioException11 = ioException10;
          if (!obj0.exists())
            throw Throwable.__\u003Cunmap\u003E((Exception) ioException11);
        }
        finally
        {
          resourceAsStream.close();
        }
      }
      else
      {
        string str = new StringBuilder().append("Failed to read input stream for ").append(obj0.getCanonicalPath()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str);
      }
    }

    [LineNumberTable(new byte[] {112, 104, 164, 105, 223, 6, 2, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool canExecute([In] File obj0)
    {
      int num;
      try
      {
        if (obj0.canExecute())
          return true;
        if (obj0.setExecutable(true))
          num = obj0.canExecute() ? 1 : 0;
        else
          goto label_8;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_7;
      }
      return num != 0;
label_7:
label_8:
      return false;
    }

    [LineNumberTable(6)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal SteamSharedLibraryLoader()
    {
    }

    [LineNumberTable(new byte[] {159, 140, 173, 107, 139, 125, 111, 125, 108, 125, 140, 191, 22, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SteamSharedLibraryLoader()
    {
      if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamSharedLibraryLoader"))
        return;
      string property1 = java.lang.System.getProperty("os.name");
      string property2 = java.lang.System.getProperty("os.arch");
      string str1 = property1;
      object obj1 = (object) "Windows";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      if (String.instancehelper_contains(str1, charSequence2))
      {
        SteamSharedLibraryLoader.OS = SteamSharedLibraryLoader.PLATFORM.Windows;
      }
      else
      {
        string str2 = property1;
        object obj2 = (object) "Linux";
        charSequence1.__\u003Cref\u003E = (__Null) obj2;
        CharSequence charSequence3 = charSequence1;
        if (String.instancehelper_contains(str2, charSequence3))
        {
          SteamSharedLibraryLoader.OS = SteamSharedLibraryLoader.PLATFORM.Linux;
        }
        else
        {
          string str3 = property1;
          object obj3 = (object) "Mac";
          charSequence1.__\u003Cref\u003E = (__Null) obj3;
          CharSequence charSequence4 = charSequence1;
          if (String.instancehelper_contains(str3, charSequence4))
          {
            SteamSharedLibraryLoader.OS = SteamSharedLibraryLoader.PLATFORM.MacOS;
          }
          else
          {
            string str4 = new StringBuilder().append("Unknown host architecture: ").append(property1).append(", ").append(property2).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new RuntimeException(str4);
          }
        }
      }
      SteamSharedLibraryLoader.IS_64_BIT = String.instancehelper_equals(property2, (object) "amd64") || String.instancehelper_equals(property2, (object) "x86_64");
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SteamSharedLibraryLoader.__\u003CcallerID\u003E == null)
        SteamSharedLibraryLoader.__\u003CcallerID\u003E = (CallerID) new SteamSharedLibraryLoader.__\u003CCallerID\u003E();
      return SteamSharedLibraryLoader.__\u003CcallerID\u003E;
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0031 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024com\u0024codedisaster\u0024steamworks\u0024SteamSharedLibraryLoader\u0024PLATFORM;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(28)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0031()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamSharedLibraryLoader$1"))
          return;
        SteamSharedLibraryLoader.\u0031.\u0024SwitchMap\u0024com\u0024codedisaster\u0024steamworks\u0024SteamSharedLibraryLoader\u0024PLATFORM = new int[SteamSharedLibraryLoader.PLATFORM.values().Length];
        try
        {
          SteamSharedLibraryLoader.\u0031.\u0024SwitchMap\u0024com\u0024codedisaster\u0024steamworks\u0024SteamSharedLibraryLoader\u0024PLATFORM[SteamSharedLibraryLoader.PLATFORM.Windows.ordinal()] = 1;
          goto label_6;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_6:
        try
        {
          SteamSharedLibraryLoader.\u0031.\u0024SwitchMap\u0024com\u0024codedisaster\u0024steamworks\u0024SteamSharedLibraryLoader\u0024PLATFORM[SteamSharedLibraryLoader.PLATFORM.Linux.ordinal()] = 2;
          goto label_10;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_10:
        try
        {
          SteamSharedLibraryLoader.\u0031.\u0024SwitchMap\u0024com\u0024codedisaster\u0024steamworks\u0024SteamSharedLibraryLoader\u0024PLATFORM[SteamSharedLibraryLoader.PLATFORM.MacOS.ordinal()] = 3;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0031() => throw null;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lcom/codedisaster/steamworks/SteamSharedLibraryLoader$PLATFORM;>;")]
    [Modifiers]
    [Serializable]
    internal sealed class PLATFORM : Enum
    {
      [Modifiers]
      public static SteamSharedLibraryLoader.PLATFORM Windows;
      [Modifiers]
      public static SteamSharedLibraryLoader.PLATFORM Linux;
      [Modifiers]
      public static SteamSharedLibraryLoader.PLATFORM MacOS;
      [Modifiers]
      private static SteamSharedLibraryLoader.PLATFORM[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(176)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamSharedLibraryLoader.PLATFORM[] values() => (SteamSharedLibraryLoader.PLATFORM[]) SteamSharedLibraryLoader.PLATFORM.\u0024VALUES.Clone();

      [Signature("()V")]
      [LineNumberTable(176)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private PLATFORM([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(176)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static SteamSharedLibraryLoader.PLATFORM valueOf([In] string obj0) => (SteamSharedLibraryLoader.PLATFORM) Enum.valueOf((Class) ClassLiteral<SteamSharedLibraryLoader.PLATFORM>.Value, obj0);

      [LineNumberTable(new byte[] {159, 98, 109, 112, 112, 240, 61})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static PLATFORM()
      {
        if (ByteCodeHelper.isAlreadyInited("com.codedisaster.steamworks.SteamSharedLibraryLoader$PLATFORM"))
          return;
        SteamSharedLibraryLoader.PLATFORM.Windows = new SteamSharedLibraryLoader.PLATFORM(nameof (Windows), 0);
        SteamSharedLibraryLoader.PLATFORM.Linux = new SteamSharedLibraryLoader.PLATFORM(nameof (Linux), 1);
        SteamSharedLibraryLoader.PLATFORM.MacOS = new SteamSharedLibraryLoader.PLATFORM(nameof (MacOS), 2);
        SteamSharedLibraryLoader.PLATFORM.\u0024VALUES = new SteamSharedLibraryLoader.PLATFORM[3]
        {
          SteamSharedLibraryLoader.PLATFORM.Windows,
          SteamSharedLibraryLoader.PLATFORM.Linux,
          SteamSharedLibraryLoader.PLATFORM.MacOS
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
