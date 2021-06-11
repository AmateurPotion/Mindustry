// Decompiled with JetBrains decompiler
// Type: arc.util.SharedLibraryLoader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class SharedLibraryLoader : Object
  {
    [Modifiers]
    [Signature("Ljava/util/HashSet<Ljava/lang/String;>;")]
    private static HashSet loadedLibraries;
    private string nativesJar;
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isLoaded(string libraryName)
    {
      lock ((object) ClassLiteral<SharedLibraryLoader>.Value)
        return SharedLibraryLoader.loadedLibraries.contains((object) libraryName);
    }

    [LineNumberTable(new byte[] {10, 127, 17, 127, 51, 127, 27})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string mapLibraryName(string libraryName)
    {
      if (OS.isWindows)
        return new StringBuilder().append(libraryName).append(!OS.is64Bit ? ".dll" : "64.dll").toString();
      if (OS.isLinux)
        return new StringBuilder().append("lib").append(libraryName).append(!OS.isARM ? "" : "arm").append(!OS.is64Bit ? ".so" : "64.so").toString();
      return OS.isMac ? new StringBuilder().append("lib").append(libraryName).append(!OS.is64Bit ? ".dylib" : "64.dylib").toString() : libraryName;
    }

    [LineNumberTable(new byte[] {160, 139, 142, 172, 159, 22, 206, 104, 159, 10, 34, 193, 127, 22, 172, 127, 7, 172, 103, 172, 118, 104, 112, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void loadFile([In] string obj0)
    {
      string sourceCrc = this.crc(this.readFile(obj0));
      string name = new File(obj0).getName();
      File.__\u003Cclinit\u003E();
      File extractedFile1 = new File(new StringBuilder().append(java.lang.System.getProperty("java.io.tmpdir")).append("/arc/").append(sourceCrc).toString(), name);
      Exception exception;
      if ((exception = this.loadFile(obj0, sourceCrc, extractedFile1)) == null)
        return;
      try
      {
        File tempFile = File.createTempFile(sourceCrc, (string) null);
        if (tempFile.delete())
        {
          if (this.loadFile(obj0, sourceCrc, tempFile) == null)
            return;
          goto label_8;
        }
        else
          goto label_8;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
label_8:
      File.__\u003Cclinit\u003E();
      File extractedFile2 = new File(new StringBuilder().append(java.lang.System.getProperty("user.home")).append("/.arc/").append(sourceCrc).toString(), name);
      if (this.loadFile(obj0, sourceCrc, extractedFile2) == null)
        return;
      File.__\u003Cclinit\u003E();
      File extractedFile3 = new File(new StringBuilder().append(".temp/").append(sourceCrc).toString(), name);
      if (this.loadFile(obj0, sourceCrc, extractedFile3) == null)
        return;
      File extractedFile4 = new File(name);
      if (this.loadFile(obj0, sourceCrc, extractedFile4) == null)
        return;
      File.__\u003Cclinit\u003E();
      File file = new File(java.lang.System.getProperty("java.library.path"), obj0);
      if (file.exists())
      {
        java.lang.System.load(file.getAbsolutePath(), SharedLibraryLoader.__\u003CGetCallerID\u003E());
      }
      else
      {
        Exception t = exception;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(t);
      }
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 134, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void setLoaded(string libraryName)
    {
      lock ((object) ClassLiteral<SharedLibraryLoader>.Value)
        SharedLibraryLoader.loadedLibraries.add((object) libraryName);
    }

    [LineNumberTable(new byte[] {41, 104, 127, 6, 127, 9, 226, 69, 113, 104, 127, 30, 127, 0, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual InputStream readFile(string path)
    {
      if (this.nativesJar == null)
      {
        InputStream resourceAsStream = ((Class) ClassLiteral<SharedLibraryLoader>.Value).getResourceAsStream(new StringBuilder().append("/").append(path).toString());
        if (resourceAsStream == null)
        {
          string message = new StringBuilder().append("Unable to read file for extraction: ").append(path).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        return resourceAsStream;
      }
      InputStream inputStream;
      IOException ioException1;
      try
      {
        ZipFile.__\u003Cclinit\u003E();
        ZipFile zipFile = new ZipFile(this.nativesJar);
        ZipEntry entry = zipFile.getEntry(path);
        if (entry == null)
        {
          string message = new StringBuilder().append("Couldn't find '").append(path).append("' in JAR: ").append(this.nativesJar).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        inputStream = zipFile.getInputStream(entry);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_9;
      }
      return inputStream;
label_9:
      IOException ioException2 = ioException1;
      string message1 = new StringBuilder().append("Error reading '").append(path).append("' in JAR: ").append(this.nativesJar).toString();
      IOException ioException3 = ioException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message1, (Exception) ioException3);
    }

    [LineNumberTable(new byte[] {159, 184, 115, 102, 171, 104, 102, 105, 176, 102, 38, 102, 226, 61, 129, 102, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string crc(InputStream input)
    {
      if (input == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("input cannot be null.");
      }
      CRC32 crC32 = new CRC32();
      byte[] numArray = new byte[4096];
      // ISSUE: fault handler
      try
      {
        while (true)
        {
          int num = input.read(numArray);
          if (num != -1)
            crC32.update(numArray, 0, num);
          else
            goto label_9;
        }
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      __fault
      {
        Streams.close((Closeable) input);
      }
      Streams.close((Closeable) input);
      goto label_10;
label_9:
      Streams.close((Closeable) input);
label_10:
      return Long.toString(crC32.getValue(), 16);
    }

    [LineNumberTable(new byte[] {101, 111, 127, 32, 203, 104, 104, 104, 189, 34, 193, 127, 22, 171, 127, 7, 171, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private File getExtractedFile([In] string obj0, [In] string obj1)
    {
      File.__\u003Cclinit\u003E();
      File file1 = new File(new StringBuilder().append(java.lang.System.getProperty("java.io.tmpdir")).append("/arc").append(java.lang.System.getProperty("user.name")).append("/").append(obj0).toString(), obj1);
      if (this.canWrite(file1))
        return file1;
      File file2;
      try
      {
        File tempFile = File.createTempFile(obj0, (string) null);
        if (tempFile.delete())
        {
          File file3 = new File(tempFile, obj1);
          if (this.canWrite(file3))
            file2 = file3;
          else
            goto label_8;
        }
        else
          goto label_8;
      }
      catch (IOException ex)
      {
        goto label_7;
      }
      return file2;
label_7:
label_8:
      File.__\u003Cclinit\u003E();
      File file4 = new File(new StringBuilder().append(java.lang.System.getProperty("user.home")).append("/.arc/").append(obj0).toString(), obj1);
      if (this.canWrite(file4))
        return file4;
      File.__\u003Cclinit\u003E();
      File file5 = new File(new StringBuilder().append(".temp/").append(obj0).toString(), obj1);
      if (this.canWrite(file5))
        return file5;
      return java.lang.System.getenv("APP_SANDBOX_CONTAINER_ID") != null ? file1 : (File) null;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 99, 98, 136, 152, 34, 225, 69, 111, 98, 130, 104, 104, 140, 103, 139, 105, 103, 106, 206, 102, 102, 7, 102, 102, 230, 59, 98, 159, 29, 102, 102, 161})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual File extractFile(
      string sourcePath,
      string sourceCrc,
      File extractedFile)
    {
      string str = (string) null;
      if (extractedFile.exists())
      {
        try
        {
          str = this.crc((InputStream) new FileInputStream(extractedFile));
          goto label_4;
        }
        catch (FileNotFoundException ex)
        {
        }
      }
label_4:
      if (str == null || !String.instancehelper_equals(str, (object) sourceCrc))
      {
        InputStream inputStream = (InputStream) null;
        FileOutputStream fileOutputStream = (FileOutputStream) null;
        IOException ioException1;
        // ISSUE: fault handler
        try
        {
          inputStream = this.readFile(sourcePath);
          if (extractedFile.getParentFile() != null)
            extractedFile.getParentFile().mkdirs();
          fileOutputStream = new FileOutputStream(extractedFile);
          byte[] numArray = new byte[4096];
          while (true)
          {
            int num = inputStream.read(numArray);
            if (num != -1)
              fileOutputStream.write(numArray, 0, num);
            else
              goto label_14;
          }
        }
        catch (IOException ex)
        {
          ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        }
        __fault
        {
          Streams.close((Closeable) inputStream);
          Streams.close((Closeable) fileOutputStream);
        }
        IOException ioException2 = ioException1;
        // ISSUE: fault handler
        try
        {
          IOException ioException3 = ioException2;
          string message = new StringBuilder().append("Error extracting file: ").append(sourcePath).append("\nTo: ").append(extractedFile.getAbsolutePath()).toString();
          IOException ioException4 = ioException3;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message, (Exception) ioException4);
        }
        __fault
        {
          Streams.close((Closeable) inputStream);
          Streams.close((Closeable) fileOutputStream);
        }
label_14:
        Streams.close((Closeable) inputStream);
        Streams.close((Closeable) fileOutputStream);
      }
      return extractedFile;
    }

    [LineNumberTable(new byte[] {160, 67, 135, 104, 147, 152, 103, 106, 162, 107, 212, 103, 38, 231, 60, 100, 97, 135, 103, 35, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool canWrite([In] File obj0)
    {
      File parentFile = obj0.getParentFile();
      File file;
      if (obj0.exists())
      {
        if (!obj0.canWrite() || !this.canExecute(obj0))
          return false;
        File.__\u003Cclinit\u003E();
        file = new File(parentFile, UUID.randomUUID().toString());
      }
      else
      {
        parentFile.mkdirs();
        if (!parentFile.isDirectory())
          return false;
        file = obj0;
      }
      int num;
      // ISSUE: fault handler
      try
      {
        new FileOutputStream(file).close();
        num = this.canExecute(file) ? 1 : 0;
        goto label_11;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      __fault
      {
        file.delete();
      }
      try
      {
        return false;
      }
      finally
      {
        file.delete();
      }
label_11:
      file.delete();
      return num != 0;
    }

    [LineNumberTable(new byte[] {160, 90, 108, 105, 125, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool canExecute([In] File obj0)
    {
      int num;
      try
      {
        if (obj0.canExecute())
          return true;
        obj0.setExecutable(true, false);
        num = obj0.canExecute() ? 1 : 0;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_5;
      }
      return num != 0;
label_5:
      return false;
    }

    [LineNumberTable(new byte[] {160, 180, 120, 119, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Exception loadFile(
      string sourcePath,
      string sourceCrc,
      File extractedFile)
    {
      Exception exception;
      try
      {
        java.lang.System.load(this.extractFile(sourcePath, sourceCrc, extractedFile).getAbsolutePath(), SharedLibraryLoader.__\u003CGetCallerID\u003E());
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_3;
      }
      return (Exception) null;
label_3:
      return exception;
    }

    [LineNumberTable(new byte[] {159, 163, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SharedLibraryLoader()
    {
    }

    [LineNumberTable(new byte[] {159, 169, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SharedLibraryLoader(string nativesJar)
    {
      SharedLibraryLoader sharedLibraryLoader = this;
      this.nativesJar = nativesJar;
    }

    [LineNumberTable(new byte[] {22, 136, 108, 112, 136, 103, 141, 103, 213, 243, 61, 98, 127, 5, 159, 28, 117})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void load(string libraryName)
    {
      if (OS.isIos)
        return;
      Class @class;
      System.Threading.Monitor.Enter((object) (@class = (Class) ClassLiteral<SharedLibraryLoader>.Value));
      string str;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        if (SharedLibraryLoader.isLoaded(libraryName))
        {
          System.Threading.Monitor.Exit((object) @class);
          return;
        }
        str = this.mapLibraryName(libraryName);
        try
        {
          if (OS.isAndroid)
            java.lang.System.loadLibrary(str, SharedLibraryLoader.__\u003CGetCallerID\u003E());
          else
            this.loadFile(str);
          SharedLibraryLoader.setLoaded(libraryName);
          goto label_14;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) @class);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string message = new StringBuilder().append("Couldn't load shared library '").append(str).append("' for target: ").append(java.lang.System.getProperty("os.name")).append(!OS.is64Bit ? ", 32-bit" : ", 64-bit").toString();
        Exception t = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, t);
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) @class);
      }
label_14:
      // ISSUE: fault handler
      try
      {
        System.Threading.Monitor.Exit((object) @class);
      }
      __fault
      {
        System.Threading.Monitor.Exit((object) @class);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {67, 110, 134, 115, 99, 124, 179, 127, 5, 130, 118, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual File extractFile(string sourcePath, string dirName)
    {
      File file1;
      RuntimeException runtimeException1;
      try
      {
        string sourceCrc = this.crc(this.readFile(sourcePath));
        if (dirName == null)
          dirName = sourceCrc;
        File extractedFile = this.getExtractedFile(dirName, new File(sourcePath).getName());
        if (extractedFile == null)
        {
          extractedFile = this.getExtractedFile(UUID.randomUUID().toString(), new File(sourcePath).getName());
          if (extractedFile == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException("Unable to find writable path to extract file. Is the user home directory writable?");
          }
        }
        file1 = this.extractFile(sourcePath, sourceCrc, extractedFile);
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
          runtimeException1 = (RuntimeException) m0;
          goto label_10;
        }
      }
      return file1;
label_10:
      RuntimeException runtimeException2 = runtimeException1;
      File.__\u003Cclinit\u003E();
      File file2 = new File(java.lang.System.getProperty("java.library.path"), sourcePath);
      return file2.exists() ? file2 : throw Throwable.__\u003Cunmap\u003E((Exception) runtimeException2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {92, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void extractFileTo(string sourcePath, File dir)
    {
      string sourcePath1 = sourcePath;
      string sourceCrc = this.crc(this.readFile(sourcePath));
      File.__\u003Cclinit\u003E();
      File extractedFile = new File(dir, new File(sourcePath).getName());
      this.extractFile(sourcePath1, sourceCrc, extractedFile);
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SharedLibraryLoader()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.util.SharedLibraryLoader"))
        return;
      SharedLibraryLoader.loadedLibraries = new HashSet();
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (SharedLibraryLoader.__\u003CcallerID\u003E == null)
        SharedLibraryLoader.__\u003CcallerID\u003E = (CallerID) new SharedLibraryLoader.__\u003CCallerID\u003E();
      return SharedLibraryLoader.__\u003CcallerID\u003E;
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
