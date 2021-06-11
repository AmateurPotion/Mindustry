// Decompiled with JetBrains decompiler
// Type: arc.files.ZipFi
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.util;
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

namespace arc.files
{
  public class ZipFi : Fi
  {
    private ZipFi[] children;
    private ZipFi parent;
    private string path;
    [Modifiers]
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    private ZipEntry entry;
    [Modifiers]
    private ZipFile zip;

    [LineNumberTable(new byte[] {159, 163, 247, 56, 236, 73, 167, 118, 139, 127, 6, 134, 127, 0, 105, 127, 71, 127, 20, 108, 127, 21, 101, 133, 109, 112, 172, 184, 168, 244, 69, 147, 187, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public ZipFi(Fi zipFileLoc)
      : base(new File(""), Files.FileType.__\u003C\u003Eabsolute)
    {
      ZipFi zipFi = this;
      this.children = new ZipFi[0];
      this.entry = (ZipEntry) null;
      IOException ioException1;
      try
      {
        ZipFile.__\u003Cclinit\u003E();
        this.zip = new ZipFile(zipFileLoc.file());
        this.path = "";
        Seq seq1 = Seq.with((Iterable) Collections.list(this.zip.entries())).map((Func) new ZipFi.__\u003C\u003EAnon0());
        ObjectSet objectSet = new ObjectSet();
        Iterator iterator = seq1.iterator();
label_2:
        while (iterator.hasNext())
        {
          string str1 = (string) iterator.next();
          objectSet.add((object) str1);
          while (true)
          {
            string str2 = str1;
            object obj1 = (object) "/";
            CharSequence charSequence1;
            charSequence1.__\u003Cref\u003E = (__Null) obj1;
            CharSequence charSequence2 = charSequence1;
            if (String.instancehelper_contains(str2, charSequence2) && !String.instancehelper_equals(str1, (object) "/"))
            {
              string str3 = String.instancehelper_substring(str1, 0, String.instancehelper_length(str1) - 1);
              object obj2 = (object) "/";
              charSequence1.__\u003Cref\u003E = (__Null) obj2;
              CharSequence charSequence3 = charSequence1;
              if (String.instancehelper_contains(str3, charSequence3))
              {
                int num = !String.instancehelper_endsWith(str1, "/") ? String.instancehelper_lastIndexOf(str1, 47) : String.instancehelper_lastIndexOf(String.instancehelper_substring(str1, 0, String.instancehelper_length(str1) - 1), 47);
                str1 = String.instancehelper_substring(str1, 0, num);
                objectSet.add(!String.instancehelper_endsWith(str1, "/") ? (object) new StringBuilder().append(str1).append("/").toString() : (object) str1);
              }
              else
                goto label_2;
            }
            else
              goto label_2;
          }
        }
        if (objectSet.contains((object) "/"))
        {
          this.file = new File("/");
          objectSet.remove((object) "/");
        }
        Seq seq2 = Seq.with((Iterable) objectSet).map((Func) new ZipFi.__\u003C\u003EAnon1(this));
        seq2.add((object) this);
        seq2.each((Cons) new ZipFi.__\u003C\u003EAnon2(this, seq2));
        seq2.each((Cons) new ZipFi.__\u003C\u003EAnon3(seq2));
        this.parent = (ZipFi) null;
        return;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException((Exception) ioException2);
    }

    [LineNumberTable(new byte[] {39, 107, 119, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool delete()
    {
      int num;
      IOException ioException;
      try
      {
        this.zip.close();
        num = 1;
      }
      catch (IOException ex)
      {
        ioException = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return num != 0;
label_3:
      Log.err((Exception) ioException);
      return false;
    }

    [LineNumberTable(119)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string name() => this.file.getName();

    [LineNumberTable(139)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool isDirectory() => this.entry == null || this.entry.isDirectory();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string path() => this.path;

    [LineNumberTable(new byte[] {15, 98, 107, 47, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int countSlahes([In] string obj0)
    {
      int num = 0;
      for (int index = 0; index < String.instancehelper_length(obj0); ++index)
      {
        if (String.instancehelper_charAt(obj0, index) == '/')
          ++num;
      }
      return num;
    }

    [LineNumberTable(new byte[] {23, 253, 4, 236, 125, 117, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ZipFi([In] ZipEntry obj0, [In] ZipFile obj1)
    {
      File.__\u003Cclinit\u003E();
      // ISSUE: explicit constructor call
      base.\u002Ector(new File(obj0.getName()), Files.FileType.__\u003C\u003Eabsolute);
      ZipFi zipFi = this;
      this.children = new ZipFi[0];
      this.path = String.instancehelper_replace(obj0.getName(), '\\', '/');
      this.entry = obj0;
      this.zip = obj1;
    }

    [LineNumberTable(new byte[] {30, 243, 159, 189, 236, 160, 68, 112, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ZipFi([In] string obj0, [In] ZipFile obj1)
      : base(new File(obj0), Files.FileType.__\u003C\u003Eabsolute)
    {
      ZipFi zipFi = this;
      this.children = new ZipFi[0];
      this.path = String.instancehelper_replace(obj0, '\\', '/');
      this.entry = (ZipEntry) null;
      this.zip = obj1;
    }

    [Modifiers]
    [LineNumberTable(28)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string lambda\u0024new\u00240([In] ZipEntry obj0) => String.instancehelper_replace(obj0.getName(), '\\', '/');

    [Modifiers]
    [LineNumberTable(new byte[] {159, 187, 110, 63, 6})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ZipFi lambda\u0024new\u00241([In] string obj0) => this.zip.getEntry(obj0) != null ? new ZipFi(this.zip.getEntry(obj0), this.zip) : new ZipFi(obj0, this.zip);

    [Modifiers]
    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024new\u00243([In] Seq obj0, [In] ZipFi obj1) => obj1.parent = (ZipFi) obj0.find((Boolf) new ZipFi.__\u003C\u003EAnon5(this, obj1));

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00245([In] Seq obj0, [In] ZipFi obj1) => obj1.children = (ZipFi[]) obj0.select((Boolf) new ZipFi.__\u003C\u003EAnon4(obj1)).toArray((Class) ClassLiteral<ZipFi>.Value);

    [Modifiers]
    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00244([In] ZipFi obj0, [In] ZipFi obj1) => object.ReferenceEquals((object) obj1.parent, (object) obj0);

    [Modifiers]
    [LineNumberTable(new byte[] {1, 120, 118, 127, 21, 255, 23, 61})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024new\u00242([In] ZipFi obj0, [In] ZipFi obj1)
    {
      if (obj1.isDirectory() && !object.ReferenceEquals((object) obj1, (object) obj0) && String.instancehelper_startsWith(obj0.path(), obj1.path()))
      {
        string str = String.instancehelper_substring(obj0.path(), 1 + String.instancehelper_length(obj1.path()));
        object obj = (object) "/";
        CharSequence charSequence1;
        charSequence1.__\u003Cref\u003E = (__Null) obj;
        CharSequence charSequence2 = charSequence1;
        if (!String.instancehelper_contains(str, charSequence2) || String.instancehelper_endsWith(obj0.path(), "/") && this.countSlahes(String.instancehelper_substring(obj0.path(), 1 + String.instancehelper_length(obj1.path()))) == 1)
          return true;
      }
      return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override bool exists() => true;

    [LineNumberTable(new byte[] {54, 116, 110, 2, 230, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi child(string name)
    {
      ZipFi[] children = this.children;
      int length = children.Length;
      for (int index = 0; index < length; ++index)
      {
        ZipFi zipFi = children[index];
        if (String.instancehelper_equals(zipFi.name(), (object) name))
          return (Fi) zipFi;
      }
      File.__\u003Cclinit\u003E();
      return (Fi) new ZipFi.\u0031(this, new File(this.file, name));
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi parent() => (Fi) this.parent;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Fi[] list() => (Fi[]) this.children;

    [LineNumberTable(new byte[] {94, 152, 127, 8, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override InputStream read()
    {
      if (this.entry == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new RuntimeException("Not permitted.");
      }
      InputStream inputStream;
      IOException ioException1;
      try
      {
        inputStream = this.zip.getInputStream(this.entry);
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_5;
      }
      return inputStream;
label_5:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override long length() => this.isDirectory() ? 0L : this.entry.getSize();

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString() => this.path();

    [EnclosingMethod(null, "child", "(Ljava.lang.String;)Larc.files.Fi;")]
    [SpecialName]
    internal new class \u0031 : Fi
    {
      [Modifiers]
      internal ZipFi this\u00240;

      [LineNumberTable(109)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] ZipFi obj0, [In] File obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
      }

      [MethodImpl(MethodImplOptions.NoInlining)]
      public override bool exists() => false;
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon0 : Func
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public object get([In] object obj0) => (object) ZipFi.lambda\u0024new\u00240((ZipEntry) obj0);
    }

    [SpecialName]
    private new sealed class __\u003C\u003EAnon1 : Func
    {
      private readonly ZipFi arg\u00241;

      internal __\u003C\u003EAnon1([In] ZipFi obj0) => this.arg\u00241 = obj0;

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024new\u00241((string) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly ZipFi arg\u00241;
      private readonly Seq arg\u00242;

      internal __\u003C\u003EAnon2([In] ZipFi obj0, [In] Seq obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024new\u00243(this.arg\u00242, (ZipFi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Cons
    {
      private readonly Seq arg\u00241;

      internal __\u003C\u003EAnon3([In] Seq obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => ZipFi.lambda\u0024new\u00245(this.arg\u00241, (ZipFi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      private readonly ZipFi arg\u00241;

      internal __\u003C\u003EAnon4([In] ZipFi obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (ZipFi.lambda\u0024new\u00244(this.arg\u00241, (ZipFi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Boolf
    {
      private readonly ZipFi arg\u00241;
      private readonly ZipFi arg\u00242;

      internal __\u003C\u003EAnon5([In] ZipFi obj0, [In] ZipFi obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024new\u00242(this.arg\u00242, (ZipFi) obj0) ? 1 : 0) != 0;
    }
  }
}
