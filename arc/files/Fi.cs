// Decompiled with JetBrains decompiler
// Type: arc.files.Fi
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics;
using arc.util;
using arc.util.io;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.nio.channels;
using java.util;
using java.util.zip;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.files
{
  public class Fi : Object
  {
    protected internal File file;
    protected internal Files.FileType type;

    [LineNumberTable(new byte[] {160, 73, 127, 19})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual File file()
    {
      if (!object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eexternal))
        return this.file;
      File.__\u003Cclinit\u003E();
      return new File(Core.files.getExternalStoragePath(), this.file.getPath());
    }

    [LineNumberTable(new byte[] {103, 108, 105, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string extension()
    {
      string name = this.file.getName();
      int num = String.instancehelper_lastIndexOf(name, 46);
      return num == -1 ? "" : String.instancehelper_substring(name, num + 1);
    }

    [LineNumberTable(new byte[] {162, 83, 108, 99, 103, 242, 98, 114, 141, 203})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi parent()
    {
      File file = this.file.getParentFile();
      if (file == null)
      {
        if (OS.isWindows)
          return (Fi) new Fi.\u0031(this, "", this.type);
        file = !object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eabsolute) ? new File("") : new File("/");
      }
      return new Fi(file, this.type);
    }

    [LineNumberTable(new byte[] {111, 108, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string nameWithoutExtension()
    {
      string name = this.file.getName();
      int num = String.instancehelper_lastIndexOf(name, 46);
      return num == -1 ? name : String.instancehelper_substring(name, 0, num);
    }

    [LineNumberTable(new byte[] {162, 69, 127, 5})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi child(string name)
    {
      if (String.instancehelper_length(this.file.getPath()) == 0)
        return new Fi(new File(name), this.type);
      File.__\u003Cclinit\u003E();
      return new Fi(new File(this.file, name), this.type);
    }

    [LineNumberTable(148)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool extEquals(string ext) => String.instancehelper_equalsIgnoreCase(this.extension(), ext);

    [LineNumberTable(new byte[] {159, 181, 104, 108, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fi(string fileName)
    {
      Fi fi = this;
      this.file = new File(fileName);
      this.type = Files.FileType.__\u003C\u003Eabsolute;
    }

    [LineNumberTable(new byte[] {161, 221, 127, 29, 108, 106, 104, 105, 44, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi[] list()
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot list a classpath directory: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      string[] strArray = this.file().list();
      if (strArray == null)
        return new Fi[0];
      Fi[] fiArray = new Fi[strArray.Length];
      int index = 0;
      for (int length = strArray.Length; index < length; ++index)
        fiArray[index] = this.child(strArray[index]);
      return fiArray;
    }

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string name() => String.instancehelper_isEmpty(this.file.getName()) ? this.file.getPath() : this.file.getName();

    [LineNumberTable(new byte[] {162, 157, 127, 29, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool delete()
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot delete a classpath file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal))
      {
        string message = new StringBuilder().append("Cannot delete an internal file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return this.file().delete();
    }

    [LineNumberTable(138)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string absolutePath() => String.instancehelper_replace(this.file.getAbsolutePath(), '\\', '/');

    [LineNumberTable(new byte[] {162, 142, 159, 3, 175, 159, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool exists()
    {
      switch (Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType[this.type.ordinal()])
      {
        case 1:
          if (this.file().exists())
            return true;
          goto case 2;
        case 2:
          return ((Class) ClassLiteral<Fi>.Value).getResource(new StringBuilder().append("/").append(String.instancehelper_replace(this.file.getPath(), '\\', '/')).toString()) != null;
        default:
          return this.file().exists();
      }
    }

    [LineNumberTable(266)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string readString() => this.readString("UTF-8");

    [LineNumberTable(new byte[] {162, 132, 127, 29, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool mkdirs()
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot mkdirs with a classpath file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal))
      {
        string message = new StringBuilder().append("Cannot mkdirs with an internal file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return this.file().mkdirs();
    }

    [LineNumberTable(new byte[] {161, 113, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeString(string @string) => this.writeString(@string, false);

    [LineNumberTable(446)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Writer writer(bool append) => this.writer(append, "UTF-8");

    [LineNumberTable(65)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi get(string path) => new Fi(path);

    [LineNumberTable(905)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => String.instancehelper_replace(this.file.getPath(), '\\', '/');

    [LineNumberTable(new byte[] {4, 104, 103, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fi(string fileName, Files.FileType type)
    {
      Fi fi = this;
      this.type = type;
      this.file = new File(fileName);
    }

    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Reader reader() => this.reader("UTF-8");

    [LineNumberTable(new byte[] {161, 105, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writePNG(Pixmap pixmap) => PixmapIO.writePNG(this, pixmap);

    [LineNumberTable(133)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string path() => String.instancehelper_replace(this.file.getPath(), '\\', '/');

    [LineNumberTable(new byte[] {162, 78, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi sibling(string name)
    {
      if (String.instancehelper_length(this.file.getPath()) == 0)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException("Cannot get the sibling of the root.");
      }
      File.__\u003Cclinit\u003E();
      return new Fi(new File(this.file.getParent(), name), this.type);
    }

    [LineNumberTable(new byte[] {162, 201, 104, 118, 103, 129, 104, 159, 14, 103, 159, 14, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void copyTo(Fi dest)
    {
      if (!this.isDirectory())
      {
        if (dest.isDirectory())
          dest = dest.child(this.name());
        Fi.copyFile(this, dest);
      }
      else
      {
        if (dest.exists())
        {
          if (!dest.isDirectory())
          {
            string message = new StringBuilder().append("Destination exists but is not a directory: ").append((object) dest).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException(message);
          }
        }
        else
        {
          dest.mkdirs();
          if (!dest.isDirectory())
          {
            string message = new StringBuilder().append("Destination directory cannot be created: ").append((object) dest).toString();
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new ArcRuntimeException(message);
          }
        }
        Fi.copyDirectory(this, dest.child(this.name()));
      }
    }

    [LineNumberTable(new byte[] {163, 9, 106, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (!(obj is Fi))
        return false;
      Fi fi = (Fi) obj;
      return object.ReferenceEquals((object) this.type, (object) fi.type) && String.instancehelper_equals(this.path(), (object) fi.path());
    }

    [LineNumberTable(216)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BufferedInputStream read(int bufferSize)
    {
      BufferedInputStream.__\u003Cclinit\u003E();
      return new BufferedInputStream(this.read(), bufferSize);
    }

    [LineNumberTable(415)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OutputStream write(bool append, int bufferSize) => (OutputStream) new BufferedOutputStream(this.write(append), bufferSize);

    [LineNumberTable(new byte[] {159, 28, 98, 127, 29, 127, 29, 140, 114, 99, 137, 127, 2, 98, 109, 127, 44})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Writer writer(bool append, string charset)
    {
      int num = append ? 1 : 0;
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot write to a classpath file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal))
      {
        string message = new StringBuilder().append("Cannot write to an internal file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      this.parent().mkdirs();
      OutputStreamWriter outputStreamWriter;
      IOException ioException1;
      try
      {
        FileOutputStream.__\u003Cclinit\u003E();
        FileOutputStream fileOutputStream = new FileOutputStream(this.file(), num != 0);
        if (charset == null)
          return (Writer) new OutputStreamWriter((OutputStream) fileOutputStream);
        outputStreamWriter = new OutputStreamWriter((OutputStream) fileOutputStream, charset);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_10;
      }
      return (Writer) outputStreamWriter;
label_10:
      IOException ioException2 = ioException1;
      if (this.file().isDirectory())
      {
        string message = new StringBuilder().append("Cannot open a stream to a directory: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        IOException ioException3 = ioException2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) ioException3);
      }
      string message1 = new StringBuilder().append("Error writing file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
      IOException ioException4 = ioException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message1, (Exception) ioException4);
    }

    [LineNumberTable(new byte[] {162, 221, 159, 11, 159, 11, 223, 11, 148, 103, 103, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void moveTo(Fi dest)
    {
      switch (Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType[this.type.ordinal()])
      {
        case 1:
          string message1 = new StringBuilder().append("Cannot move an internal file: ").append((object) this.file).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message1);
        case 2:
          string message2 = new StringBuilder().append("Cannot move a classpath file: ").append((object) this.file).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message2);
        case 3:
        case 4:
          if (this.file().renameTo(dest.file()))
            return;
          break;
      }
      this.copyTo(dest);
      this.delete();
      if (!this.exists() || !this.isDirectory())
        return;
      this.deleteDirectory();
    }

    [LineNumberTable(new byte[] {160, 82, 127, 40, 111, 127, 25, 127, 45, 162, 127, 12, 97, 109, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InputStream read()
    {
      if (!object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath) && (!object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal) || this.file().exists()))
      {
        if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Elocal))
        {
          if (!this.file().exists())
            goto label_3;
        }
        FileInputStream fileInputStream;
        Exception exception1;
        try
        {
          FileInputStream.__\u003Cclinit\u003E();
          fileInputStream = new FileInputStream(this.file());
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
            goto label_11;
          }
        }
        return (InputStream) fileInputStream;
label_11:
        Exception exception2 = exception1;
        if (this.file().isDirectory())
        {
          string message = new StringBuilder().append("Cannot open a stream to a directory: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
          Exception exception3 = exception2;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message, (Exception) exception3);
        }
        string message1 = new StringBuilder().append("Error reading file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        Exception exception4 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message1, (Exception) exception4);
      }
label_3:
      InputStream resourceAsStream = ((Class) ClassLiteral<Fi>.Value).getResourceAsStream(new StringBuilder().append("/").append(String.instancehelper_replace(this.file.getPath(), '\\', '/')).toString());
      if (resourceAsStream == null)
      {
        string message = new StringBuilder().append("File not found: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return resourceAsStream;
    }

    [LineNumberTable(new byte[] {162, 241, 127, 18, 135, 184, 102, 38, 230, 61, 98, 129, 102, 98, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long length()
    {
      if (!object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath) && (!object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal) || this.file.exists()))
        return this.file().length();
      InputStream inputStream = this.read();
      long num;
      // ISSUE: fault handler
      try
      {
        num = (long) inputStream.available();
        goto label_7;
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
      }
      __fault
      {
        Streams.close((Closeable) inputStream);
      }
      Streams.close((Closeable) inputStream);
      return 0;
label_7:
      Streams.close((Closeable) inputStream);
      return num;
    }

    [LineNumberTable(new byte[] {162, 63, 116})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isDirectory() => !object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath) && this.file().isDirectory();

    [LineNumberTable(new byte[] {162, 167, 127, 29, 127, 29})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool deleteDirectory()
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot delete a classpath file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal))
      {
        string message = new StringBuilder().append("Cannot delete an internal file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return Fi.deleteDirectory(this.file());
    }

    [Signature("(Larc/func/Cons<Larc/files/Fi;>;)V")]
    [LineNumberTable(new byte[] {161, 186, 104, 116, 39, 200, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void walk(Cons cons)
    {
      if (this.isDirectory())
      {
        Fi[] fiArray = this.list();
        int length = fiArray.Length;
        for (int index = 0; index < length; ++index)
          fiArray[index].walk(cons);
      }
      else
        cons.get((object) this);
    }

    [Signature("(Larc/func/Boolf<Larc/files/Fi;>;)Larc/struct/Seq<Larc/files/Fi;>;")]
    [LineNumberTable(new byte[] {161, 198, 102, 242, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq findAll(Boolf test)
    {
      Seq seq = new Seq();
      this.walk((Cons) new Fi.__\u003C\u003EAnon0(test, seq));
      return seq;
    }

    [LineNumberTable(new byte[] {160, 161, 108, 130, 99, 142, 109, 139, 104, 102, 106, 206, 102, 39, 102, 230, 60, 98, 159, 8, 102, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string readString(string charset)
    {
      StringBuilder stringBuilder = new StringBuilder(this.estimateLength());
      InputStreamReader inputStreamReader = (InputStreamReader) null;
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        inputStreamReader = charset != null ? new InputStreamReader(this.read(), charset) : new InputStreamReader(this.read());
        char[] chArray = new char[256];
        while (true)
        {
          int num = ((Reader) inputStreamReader).read(chArray);
          if (num != -1)
            stringBuilder.append(chArray, 0, num);
          else
            goto label_7;
        }
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) inputStreamReader);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        string message = new StringBuilder().append("Error reading layout file: ").append((object) this).toString();
        IOException ioException4 = ioException3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) ioException4);
      }
      __fault
      {
        Streams.close((Closeable) inputStreamReader);
      }
label_7:
      Streams.close((Closeable) inputStreamReader);
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {160, 187, 135, 218, 102, 38, 230, 60, 100, 98, 159, 8, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] readBytes()
    {
      InputStream input = this.read();
      byte[] numArray;
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        numArray = Streams.copyBytes(input, this.estimateLength());
        goto label_5;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) input);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        string message = new StringBuilder().append("Error reading file: ").append((object) this).toString();
        IOException ioException4 = ioException3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) ioException4);
      }
      __fault
      {
        Streams.close((Closeable) input);
      }
label_5:
      Streams.close((Closeable) input);
      return numArray;
    }

    [LineNumberTable(new byte[] {161, 146, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBytes(byte[] bytes) => this.writeBytes(bytes, false);

    [LineNumberTable(new byte[] {159, 191, 104, 103, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Fi(File file)
    {
      Fi fi = this;
      this.file = file;
      this.type = Files.FileType.__\u003C\u003Eabsolute;
    }

    [LineNumberTable(new byte[] {161, 238, 127, 29, 103, 103, 106, 104, 98, 109, 102, 106, 113, 101, 228, 59, 232, 71, 101, 104, 107, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi[] list(FileFilter filter)
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot list a classpath directory: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      string[] strArray = this.file().list();
      if (strArray == null)
        return new Fi[0];
      Fi[] fiArray1 = new Fi[strArray.Length];
      int length1 = 0;
      int index = 0;
      for (int length2 = strArray.Length; index < length2; ++index)
      {
        Fi fi = this.child(strArray[index]);
        if (filter.accept(fi.file()))
        {
          fiArray1[length1] = fi;
          ++length1;
        }
      }
      if (length1 < strArray.Length)
      {
        Fi[] fiArray2 = new Fi[length1];
        ByteCodeHelper.arraycopy((object) fiArray1, 0, (object) fiArray2, 0, length1);
        fiArray1 = fiArray2;
      }
      return fiArray1;
    }

    [LineNumberTable(new byte[] {159, 44, 162, 127, 29, 127, 29, 140, 127, 13, 97, 109, 127, 43})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OutputStream write(bool append)
    {
      int num = append ? 1 : 0;
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot write to a classpath file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal))
      {
        string message = new StringBuilder().append("Cannot write to an internal file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      this.parent().mkdirs();
      FileOutputStream fileOutputStream;
      Exception exception1;
      try
      {
        FileOutputStream.__\u003Cclinit\u003E();
        fileOutputStream = new FileOutputStream(this.file(), num != 0);
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
          goto label_10;
        }
      }
      return (OutputStream) fileOutputStream;
label_10:
      Exception exception2 = exception1;
      if (this.file().isDirectory())
      {
        string message = new StringBuilder().append("Cannot open a stream to a directory: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        Exception exception3 = exception2;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) exception3);
      }
      string message1 = new StringBuilder().append("Error writing file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
      Exception exception4 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message1, (Exception) exception4);
    }

    [LineNumberTable(new byte[] {159, 120, 66, 107, 103, 102, 105, 106, 107, 99, 139, 233, 58, 230, 74})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void emptyDirectory([In] File obj0, [In] bool obj1)
    {
      int num = obj1 ? 1 : 0;
      if (!obj0.exists())
        return;
      File[] fileArray = obj0.listFiles();
      if (fileArray == null)
        return;
      int index = 0;
      for (int length = fileArray.Length; index < length; ++index)
      {
        if (!fileArray[index].isDirectory())
          fileArray[index].delete();
        else if (num != 0)
          Fi.emptyDirectory(fileArray[index], true);
        else
          Fi.deleteDirectory(fileArray[index]);
      }
    }

    [LineNumberTable(new byte[] {54, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool deleteDirectory([In] File obj0)
    {
      Fi.emptyDirectory(obj0, false);
      return obj0.delete();
    }

    [LineNumberTable(new byte[] {159, 36, 130, 130, 104, 217, 102, 102, 6, 102, 102, 228, 59, 98, 159, 44, 102, 102, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void write(InputStream input, bool append)
    {
      int num = append ? 1 : 0;
      OutputStream output = (OutputStream) null;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        output = this.write(num != 0);
        Streams.copy(input, output);
        goto label_7;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      __fault
      {
        Streams.close((Closeable) input);
        Streams.close((Closeable) output);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string message = new StringBuilder().append("Error stream writing to file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        Exception exception4 = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) exception4);
      }
      __fault
      {
        Streams.close((Closeable) input);
        Streams.close((Closeable) output);
      }
label_7:
      Streams.close((Closeable) input);
      Streams.close((Closeable) output);
    }

    [LineNumberTable(new byte[] {68, 103, 103, 112, 111, 105, 139, 233, 59, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void copyDirectory([In] Fi obj0, [In] Fi obj1)
    {
      obj1.mkdirs();
      Fi[] fiArray = obj0.list();
      int length = fiArray.Length;
      for (int index = 0; index < length; ++index)
      {
        Fi fi1 = fiArray[index];
        Fi fi2 = obj1.child(fi1.name());
        if (fi1.isDirectory())
          Fi.copyDirectory(fi1, fi2);
        else
          Fi.copyFile(fi1, fi2);
      }
    }

    [LineNumberTable(new byte[] {60, 223, 5, 226, 61, 97, 191, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void copyFile([In] Fi obj0, [In] Fi obj1)
    {
      Exception exception1;
      try
      {
        obj1.write(obj0.read(), false);
        return;
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
      string message = new StringBuilder().append("Error copying source file: ").append((object) obj0.file).append(" (").append((object) obj0.type).append(")\nTo destination: ").append((object) obj1.file).append(" (").append((object) obj1.type).append(")").toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message, (Exception) exception3);
    }

    [LineNumberTable(new byte[] {160, 118, 135, 125, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Reader reader(string charset)
    {
      InputStream inputStream = this.read();
      InputStreamReader inputStreamReader;
      UnsupportedEncodingException encodingException1;
      try
      {
        inputStreamReader = new InputStreamReader(inputStream, charset);
      }
      catch (UnsupportedEncodingException ex)
      {
        encodingException1 = (UnsupportedEncodingException) ByteCodeHelper.MapException<UnsupportedEncodingException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_4;
      }
      return (Reader) inputStreamReader;
label_4:
      UnsupportedEncodingException encodingException2 = encodingException1;
      Streams.close((Closeable) inputStream);
      string message = new StringBuilder().append("Error reading file: ").append((object) this).toString();
      UnsupportedEncodingException encodingException3 = encodingException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message, (Exception) encodingException3);
    }

    [LineNumberTable(new byte[] {160, 141, 127, 9, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BufferedReader reader(int bufferSize, string charset)
    {
      BufferedReader bufferedReader;
      UnsupportedEncodingException encodingException1;
      try
      {
        bufferedReader = new BufferedReader((Reader) new InputStreamReader(this.read(), charset), bufferSize);
      }
      catch (UnsupportedEncodingException ex)
      {
        encodingException1 = (UnsupportedEncodingException) ByteCodeHelper.MapException<UnsupportedEncodingException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return bufferedReader;
label_3:
      UnsupportedEncodingException encodingException2 = encodingException1;
      string message = new StringBuilder().append("Error reading file: ").append((object) this).toString();
      UnsupportedEncodingException encodingException3 = encodingException2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message, (Exception) encodingException3);
    }

    [LineNumberTable(new byte[] {160, 198, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int estimateLength()
    {
      int num = (int) this.length();
      return num != 0 ? num : 512;
    }

    [LineNumberTable(new byte[] {160, 239, 127, 24, 130, 127, 11, 103, 117, 108, 213, 102, 39, 230, 60, 102, 98, 159, 39, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ByteBuffer map(FileChannel.MapMode mode)
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot map a classpath file: ").append((object) this).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      RandomAccessFile randomAccessFile = (RandomAccessFile) null;
      MappedByteBuffer mappedByteBuffer1;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        RandomAccessFile.__\u003Cclinit\u003E();
        randomAccessFile = new RandomAccessFile(this.file, !object.ReferenceEquals((object) mode, (object) FileChannel.MapMode.READ_ONLY) ? "rw" : "r");
        MappedByteBuffer mappedByteBuffer2 = randomAccessFile.getChannel().map(mode, 0L, this.file.length());
        ((ByteBuffer) mappedByteBuffer2).order(ByteOrder.nativeOrder());
        mappedByteBuffer1 = mappedByteBuffer2;
        goto label_9;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      __fault
      {
        Streams.close((Closeable) randomAccessFile);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string message = new StringBuilder().append("Error memory mapping file: ").append((object) this).append(" (").append((object) this.type).append(")").toString();
        Exception exception4 = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) exception4);
      }
      __fault
      {
        Streams.close((Closeable) randomAccessFile);
      }
label_9:
      Streams.close((Closeable) randomAccessFile);
      return (ByteBuffer) mappedByteBuffer1;
    }

    [LineNumberTable(new byte[] {159, 19, 98, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeString(string @string, bool append)
    {
      int num = append ? 1 : 0;
      this.writeString(@string, num != 0, "UTF-8");
    }

    [LineNumberTable(new byte[] {159, 16, 66, 130, 105, 217, 102, 38, 102, 228, 60, 98, 159, 44, 102, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeString(string @string, bool append, string charset)
    {
      int num = append ? 1 : 0;
      Writer writer = (Writer) null;
      Exception exception1;
      // ISSUE: fault handler
      try
      {
        writer = this.writer(num != 0, charset);
        writer.write(@string);
        goto label_7;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          exception1 = (Exception) m0;
      }
      __fault
      {
        Streams.close((Closeable) writer);
      }
      Exception exception2 = exception1;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception2;
        string message = new StringBuilder().append("Error writing file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        Exception exception4 = exception3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) exception4);
      }
      __fault
      {
        Streams.close((Closeable) writer);
      }
label_7:
      Streams.close((Closeable) writer);
    }

    [LineNumberTable(new byte[] {159, 11, 130, 136, 212, 102, 38, 102, 228, 60, 98, 159, 44, 102, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBytes(byte[] bytes, bool append)
    {
      OutputStream outputStream = this.write(append);
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        outputStream.write(bytes);
        goto label_5;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) outputStream);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        string message = new StringBuilder().append("Error writing file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        IOException ioException4 = ioException3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) ioException4);
      }
      __fault
      {
        Streams.close((Closeable) outputStream);
      }
label_5:
      Streams.close((Closeable) outputStream);
    }

    [LineNumberTable(new byte[] {9, 104, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Fi(File file, Files.FileType type)
    {
      Fi fi = this;
      this.file = file;
      this.type = type;
    }

    [LineNumberTable(new byte[] {158, 196, 162, 127, 29, 127, 29, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void emptyDirectory(bool preserveTree)
    {
      int num = preserveTree ? 1 : 0;
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot delete a classpath file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Einternal))
      {
        string message = new StringBuilder().append("Cannot delete an internal file: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      Fi.emptyDirectory(this.file(), num != 0);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {161, 200, 105, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024findAll\u00240([In] Boolf obj0, [In] Seq obj1, [In] Fi obj2)
    {
      if (!obj0.get((object) obj2))
        return;
      obj1.add((object) obj2);
    }

    [LineNumberTable(new byte[] {159, 173, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal Fi()
    {
    }

    [LineNumberTable(new byte[] {20, 127, 3, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi tempFile(string prefix)
    {
      Fi fi;
      IOException ioException1;
      try
      {
        fi = new Fi(File.createTempFile(prefix, (string) null));
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return fi;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("Unable to create temp file.", (Exception) ioException2);
    }

    [LineNumberTable(new byte[] {28, 104, 127, 14, 127, 14, 124, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi tempDirectory(string prefix)
    {
      Fi fi;
      IOException ioException1;
      try
      {
        File tempFile = File.createTempFile(prefix, (string) null);
        if (!tempFile.delete())
        {
          string str = new StringBuilder().append("Unable to delete temp file: ").append((object) tempFile).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str);
        }
        if (!tempFile.mkdir())
        {
          string str = new StringBuilder().append("Unable to create temp directory: ").append((object) tempFile).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str);
        }
        fi = new Fi(tempFile);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_7;
      }
      return fi;
label_7:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException("Unable to create temp file.", (Exception) ioException2);
    }

    [LineNumberTable(new byte[] {122, 117, 105, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string pathWithoutExtension()
    {
      string str = String.instancehelper_replace(this.file.getPath(), '\\', '/');
      int num = String.instancehelper_lastIndexOf(str, 46);
      return num == -1 ? str : String.instancehelper_substring(str, 0, num);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Files.FileType type() => this.type;

    [LineNumberTable(246)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual BufferedReader reader(int bufferSize) => this.reader(bufferSize, "UTF-8");

    [LineNumberTable(new byte[] {160, 210, 103, 162, 110, 102, 100, 205, 102, 38, 102, 230, 60, 98, 159, 8, 102, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readBytes(byte[] bytes, int offset, int size)
    {
      InputStream inputStream = this.read();
      int num1 = 0;
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        while (true)
        {
          int num2 = inputStream.read(bytes, offset + num1, size - num1);
          if (num2 > 0)
            num1 += num2;
          else
            goto label_6;
        }
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) inputStream);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        string message = new StringBuilder().append("Error reading file: ").append((object) this).toString();
        IOException ioException4 = ioException3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) ioException4);
      }
      __fault
      {
        Streams.close((Closeable) inputStream);
      }
label_6:
      Streams.close((Closeable) inputStream);
      return num1 - offset;
    }

    [LineNumberTable(345)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual ByteBuffer map() => this.map((FileChannel.MapMode) FileChannel.MapMode.READ_ONLY);

    [LineNumberTable(369)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Writes writes()
    {
      Writes.__\u003Cclinit\u003E();
      return new Writes((DataOutput) new DataOutputStream(this.write(false, 4096)));
    }

    [LineNumberTable(373)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Reads reads()
    {
      Reads.__\u003Cclinit\u003E();
      return new Reads((DataInput) new DataInputStream((InputStream) this.read(4096)));
    }

    [LineNumberTable(377)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Writes writesDeflate()
    {
      Writes.__\u003Cclinit\u003E();
      return new Writes((DataOutput) new DataOutputStream((OutputStream) new DeflaterOutputStream(this.write(false, 4096))));
    }

    [LineNumberTable(381)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Reads readsDeflate()
    {
      Reads.__\u003Cclinit\u003E();
      return new Reads((DataInput) new DataInputStream((InputStream) new InflaterInputStream((InputStream) this.read(4096))));
    }

    [LineNumberTable(385)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual OutputStream write() => this.write(false);

    [LineNumberTable(new byte[] {159, 7, 163, 136, 214, 102, 38, 102, 228, 60, 98, 159, 44, 102, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeBytes(byte[] bytes, int offset, int length, bool append)
    {
      OutputStream outputStream = this.write(append);
      IOException ioException1;
      // ISSUE: fault handler
      try
      {
        outputStream.write(bytes, offset, length);
        goto label_5;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      __fault
      {
        Streams.close((Closeable) outputStream);
      }
      IOException ioException2 = ioException1;
      // ISSUE: fault handler
      try
      {
        IOException ioException3 = ioException2;
        string message = new StringBuilder().append("Error writing file: ").append((object) this.file).append(" (").append((object) this.type).append(")").toString();
        IOException ioException4 = ioException3;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message, (Exception) ioException4);
      }
      __fault
      {
        Streams.close((Closeable) outputStream);
      }
label_5:
      Streams.close((Closeable) outputStream);
    }

    [Signature("()Larc/struct/Seq<Larc/files/Fi;>;")]
    [LineNumberTable(new byte[] {161, 209, 102, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq findAll()
    {
      Seq seq1 = new Seq();
      Seq seq2 = seq1;
      Objects.requireNonNull((object) seq2);
      this.walk((Cons) new Fi.__\u003C\u003EAnon1(seq2));
      return seq1;
    }

    [LineNumberTable(new byte[] {162, 11, 127, 29, 103, 103, 106, 104, 98, 109, 102, 109, 107, 228, 60, 232, 70, 101, 104, 107, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi[] list(FilenameFilter filter)
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot list a classpath directory: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      File file = this.file();
      string[] strArray = file.list();
      if (strArray == null)
        return new Fi[0];
      Fi[] fiArray1 = new Fi[strArray.Length];
      int length1 = 0;
      int index = 0;
      for (int length2 = strArray.Length; index < length2; ++index)
      {
        string name = strArray[index];
        if (filter.accept(file, name))
        {
          fiArray1[length1] = this.child(name);
          ++length1;
        }
      }
      if (length1 < strArray.Length)
      {
        Fi[] fiArray2 = new Fi[length1];
        ByteCodeHelper.arraycopy((object) fiArray1, 0, (object) fiArray2, 0, length1);
        fiArray1 = fiArray2;
      }
      return fiArray1;
    }

    [LineNumberTable(new byte[] {162, 38, 127, 29, 108, 106, 104, 98, 107, 101, 108, 107, 228, 60, 230, 70, 101, 104, 107, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi[] list(string suffix)
    {
      if (object.ReferenceEquals((object) this.type, (object) Files.FileType.__\u003C\u003Eclasspath))
      {
        string message = new StringBuilder().append("Cannot list a classpath directory: ").append((object) this.file).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      string[] strArray = this.file().list();
      if (strArray == null)
        return new Fi[0];
      Fi[] fiArray1 = new Fi[strArray.Length];
      int length1 = 0;
      int index = 0;
      for (int length2 = strArray.Length; index < length2; ++index)
      {
        string name = strArray[index];
        if (String.instancehelper_endsWith(name, suffix))
        {
          fiArray1[length1] = this.child(name);
          ++length1;
        }
      }
      if (length1 < strArray.Length)
      {
        Fi[] fiArray2 = new Fi[length1];
        ByteCodeHelper.arraycopy((object) fiArray1, 0, (object) fiArray2, 0, length1);
        fiArray1 = fiArray2;
      }
      return fiArray1;
    }

    [LineNumberTable(new byte[] {162, 177, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void emptyDirectory() => this.emptyDirectory(false);

    [LineNumberTable(886)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long lastModified() => this.file().lastModified();

    [LineNumberTable(new byte[] {163, 16, 98, 113, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode() => (1 * 37 + this.type.hashCode()) * 67 + String.instancehelper_hashCode(this.path());

    [EnclosingMethod(null, "parent", "()Larc.files.Fi;")]
    [SpecialName]
    internal class \u0031 : Fi
    {
      internal Fi[] children;
      [Modifiers]
      internal Fi this\u00240;

      [LineNumberTable(new byte[] {162, 86, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Fi obj0, [In] string obj1, [In] Files.FileType obj2)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1, obj2);
        Fi.\u0031 obj = this;
        this.children = (Fi[]) Seq.with((object[]) File.listRoots()).map((Func) new Fi.\u0031.__\u003C\u003EAnon0()).toArray((Class) ClassLiteral<Fi>.Value);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Fi[] list() => this.children;

      [Modifiers]
      [LineNumberTable(742)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static bool lambda\u0024list\u00240([In] FileFilter obj0, [In] Fi obj1) => obj0.accept(obj1.file);

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Fi parent() => (Fi) this;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool isDirectory() => true;

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool exists() => true;

      [LineNumberTable(732)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Fi child([In] string obj0) => new Fi(new File(obj0));

      [LineNumberTable(742)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Fi[] list([In] FileFilter obj0) => (Fi[]) Seq.select((object[]) this.list(), (Boolf) new Fi.\u0031.__\u003C\u003EAnon1(obj0)).toArray((Class) ClassLiteral<Fi>.Value);

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Func
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public object get([In] object obj0) => (object) new Fi((File) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Boolf
      {
        private readonly FileFilter arg\u00241;

        internal __\u003C\u003EAnon1([In] FileFilter obj0) => this.arg\u00241 = obj0;

        public bool get([In] object obj0) => (Fi.\u0031.lambda\u0024list\u00240(this.arg\u00241, (Fi) obj0) ? 1 : 0) != 0;
      }
    }

    [InnerClass]
    [EnclosingMethod(null, null, null)]
    [Modifiers]
    [SpecialName]
    internal class \u0032 : Object
    {
      [Modifiers]
      internal static int[] \u0024SwitchMap\u0024arc\u0024Files\u0024FileType;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(768)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static \u0032()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.files.Fi$2"))
          return;
        Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType = new int[Files.FileType.values().Length];
        try
        {
          Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType[Files.FileType.__\u003C\u003Einternal.ordinal()] = 1;
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
          Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType[Files.FileType.__\u003C\u003Eclasspath.ordinal()] = 2;
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
          Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType[Files.FileType.__\u003C\u003Eabsolute.ordinal()] = 3;
          goto label_14;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
label_14:
        try
        {
          Fi.\u0032.\u0024SwitchMap\u0024arc\u0024Files\u0024FileType[Files.FileType.__\u003C\u003Eexternal.ordinal()] = 4;
        }
        catch (Exception ex)
        {
          if (ByteCodeHelper.MapException<NoSuchFieldError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
            throw;
        }
      }

      \u0032() => throw null;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Cons
    {
      private readonly Boolf arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon0([In] Boolf obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => Fi.lambda\u0024findAll\u00240(this.arg\u00241, this.arg\u00242, (Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon1([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.add((object) (Fi) obj0);
    }
  }
}
