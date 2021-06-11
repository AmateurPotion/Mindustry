// Decompiled with JetBrains decompiler
// Type: mindustry.io.SaveIO
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.util;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using java.util.zip;
using mindustry.core;
using mindustry.ctype;
using mindustry.game;
using mindustry.io.legacy;
using mindustry.io.versions;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;

namespace mindustry.io
{
  public class SaveIO : Object
  {
    internal static byte[] __\u003C\u003Eheader;
    [Signature("Larc/struct/IntMap<Lmindustry/io/SaveVersion;>;")]
    internal static IntMap __\u003C\u003Eversions;
    [Signature("Larc/struct/Seq<Lmindustry/io/SaveVersion;>;")]
    internal static Seq __\u003C\u003EversionArray;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 183, 103, 143, 216, 226, 61, 97, 111, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void save(Fi file)
    {
      int num = file.exists() ? 1 : 0;
      if (num != 0)
        file.moveTo(SaveIO.backupFileFor(file));
      Exception exception1;
      try
      {
        SaveIO.write(file);
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      if (num != 0)
        SaveIO.backupFileFor(file).moveTo(file);
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(exception3);
    }

    [Throws(new string[] {"mindustry.io.SaveIO$SaveException"})]
    [LineNumberTable(new byte[] {90, 255, 9, 73, 229, 56, 97, 102, 127, 18, 104, 152, 177})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load(Fi file, WorldContext context)
    {
      SaveIO.SaveException saveException1;
      try
      {
        SaveIO.load((InputStream) new InflaterInputStream((InputStream) file.read(8192)), context);
        return;
      }
      catch (SaveIO.SaveException ex)
      {
        saveException1 = (SaveIO.SaveException) ByteCodeHelper.MapException<SaveIO.SaveException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
      }
      SaveIO.SaveException saveException2 = saveException1;
      Log.err((Exception) saveException2);
      Fi fi = file.sibling(new StringBuilder().append(file.name()).append("-backup.").append(file.extension()).toString());
      if (fi.exists())
      {
        SaveIO.load((InputStream) new InflaterInputStream((InputStream) fi.read(8192)), context);
      }
      else
      {
        Exception cause = Throwable.instancehelper_getCause((Exception) saveException2);
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SaveIO.SaveException(cause);
      }
    }

    [Throws(new string[] {"mindustry.io.SaveIO$SaveException"})]
    [LineNumberTable(new byte[] {84, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load(Fi file)
    {
      Fi file1 = file;
      World.Context context1 = Vars.world.__\u003C\u003Econtext;
      WorldContext context2;
      if (context1 != null)
        context2 = context1 is WorldContext worldContext2 ? worldContext2 : throw new IncompatibleClassChangeError();
      else
        context2 = (WorldContext) null;
      SaveIO.load(file1, context2);
    }

    [LineNumberTable(new byte[] {29, 127, 2, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SaveMeta getMeta(Fi file)
    {
      SaveMeta meta;
      Exception th;
      try
      {
        meta = SaveIO.getMeta(SaveIO.getStream(file));
      }
      catch (Exception ex)
      {
        th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_3;
      }
      return meta;
label_3:
      Log.err(th);
      return SaveIO.getMeta(SaveIO.getBackupStream(file));
    }

    [LineNumberTable(104)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi backupFileFor(Fi file) => file.sibling(new StringBuilder().append(file.name()).append("-backup.").append(file.extension()).toString());

    [LineNumberTable(new byte[] {10, 118, 118, 61, 36, 159, 63, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSaveValid(Fi file)
    {
      DataInputStream stream;
      int num;
      Exception exception1;
      try
      {
        stream = new DataInputStream((InputStream) new InflaterInputStream((InputStream) file.read(8192)));
        try
        {
          num = SaveIO.isSaveValid(stream) ? 1 : 0;
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_5;
        }
        ((FilterInputStream) stream).close();
        goto label_7;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_6;
      }
label_5:
      Exception exception2 = exception1;
      Exception exception3;
      Exception exception4;
      try
      {
        exception3 = exception2;
        try
        {
          ((FilterInputStream) stream).close();
          goto label_17;
        }
        catch (Exception ex)
        {
          exception4 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
        goto label_13;
      }
      Exception exception5 = exception4;
      try
      {
        Exception exception6 = exception5;
        Throwable.instancehelper_addSuppressed(exception3, exception6);
        goto label_17;
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_20;
label_13:
      local = null;
      goto label_20;
label_17:
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      catch (Exception ex)
      {
        ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 2);
      }
      local = null;
      goto label_20;
label_6:
      local = null;
      goto label_20;
label_7:
      return num != 0;
label_20:
      return false;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {125, 108, 103, 109, 159, 36})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void readHeader(DataInput input)
    {
      byte[] numArray = new byte[SaveIO.__\u003C\u003Eheader.Length];
      input.readFully(numArray);
      if (!Arrays.equals(numArray, SaveIO.__\u003C\u003Eheader))
      {
        string str = new StringBuilder().append("Incorrect header! Expecting: ").append(Arrays.toString(SaveIO.__\u003C\u003Eheader)).append("; Actual: ").append(Arrays.toString(numArray)).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str);
      }
    }

    [LineNumberTable(37)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SaveVersion getSaveWriter(int version) => (SaveVersion) SaveIO.__\u003C\u003Eversions.get(version);

    [LineNumberTable(new byte[] {58, 119})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void write(Fi file, StringMap tags) => SaveIO.write((OutputStream) new FastDeflaterOutputStream(file.write(false, 8192)), tags);

    [LineNumberTable(new byte[] {62, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void write(Fi file) => SaveIO.write(file, (StringMap) null);

    [LineNumberTable(new byte[] {19, 103, 119, 97, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static bool isSaveValid(DataInputStream stream)
    {
      int num;
      Exception th;
      try
      {
        SaveIO.getMeta(stream);
        num = 1;
      }
      catch (Exception ex)
      {
        th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_3;
      }
      return num != 0;
label_3:
      Log.err(th);
      return false;
    }

    [LineNumberTable(new byte[] {39, 102, 103, 119, 102, 119, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SaveMeta getMeta(DataInputStream stream)
    {
      SaveMeta saveMeta;
      IOException ioException1;
      try
      {
        SaveIO.readHeader((DataInput) stream);
        int key = stream.readInt();
        SaveMeta meta = ((SaveVersion) SaveIO.__\u003C\u003Eversions.get(key)).getMeta((DataInput) stream);
        ((FilterInputStream) stream).close();
        saveMeta = meta;
      }
      catch (IOException ex)
      {
        ioException1 = (IOException) ByteCodeHelper.MapException<IOException>((Exception) ex, (ByteCodeHelper.MapFlags) 1);
        goto label_3;
      }
      return saveMeta;
label_3:
      IOException ioException2 = ioException1;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException((Exception) ioException2);
    }

    [LineNumberTable(52)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DataInputStream getStream(Fi file) => new DataInputStream((InputStream) new InflaterInputStream((InputStream) file.read(8192)));

    [LineNumberTable(56)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static DataInputStream getBackupStream(Fi file) => new DataInputStream((InputStream) new InflaterInputStream((InputStream) SaveIO.backupFileFor(file).read(8192)));

    [LineNumberTable(new byte[] {66, 103, 107, 112, 99, 141, 155, 255, 4, 56, 255, 72, 74, 2, 98, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void write(OutputStream os, StringMap tags)
    {
      DataOutputStream stream;
      Exception exception1;
      Exception exception2;
      try
      {
        stream = new DataOutputStream(os);
        try
        {
          ((FilterOutputStream) stream).write(SaveIO.__\u003C\u003Eheader);
          stream.writeInt(SaveIO.getVersion().version);
          if (tags == null)
            SaveIO.getVersion().write(stream);
          else
            SaveIO.getVersion().write(stream, tags);
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_7;
        }
        ((FilterOutputStream) stream).close();
        return;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_8;
      }
label_7:
      Exception exception3 = exception1;
      Exception exception4;
      Exception exception5;
      Exception exception6;
      try
      {
        exception4 = exception3;
        try
        {
          ((FilterOutputStream) stream).close();
          goto label_18;
        }
        catch (Exception ex)
        {
          exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_14;
      }
      Exception exception7 = exception5;
      Exception exception8;
      try
      {
        Exception exception9 = exception7;
        Throwable.instancehelper_addSuppressed(exception4, exception9);
        goto label_18;
      }
      catch (Exception ex)
      {
        exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception10 = exception8;
      goto label_21;
label_14:
      exception10 = exception6;
      goto label_21;
label_18:
      Exception exception11;
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception4);
      }
      catch (Exception ex)
      {
        exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception10 = exception11;
      goto label_21;
label_8:
      exception10 = exception2;
label_21:
      Exception exception12 = exception10;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(exception12);
    }

    [LineNumberTable(171)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SaveVersion getVersion() => (SaveVersion) SaveIO.__\u003C\u003EversionArray.peek();

    [Throws(new string[] {"mindustry.io.SaveIO$SaveException"})]
    [LineNumberTable(new byte[] {104, 110, 106, 102, 103, 145, 105, 122, 190, 107, 107, 255, 5, 51, 255, 17, 75, 107, 107, 31, 40, 107, 107, 31, 14, 107, 107, 236, 59, 180, 107, 107, 245, 51, 255, 7, 75, 107, 107, 31, 16, 107, 107, 25, 107, 107, 5, 107, 107, 230, 59, 98, 141, 107, 107, 97})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load(InputStream @is, WorldContext context)
    {
      CounterInputStream counter;
      DataInputStream stream;
      Exception exception1;
      Exception exception2;
      Exception exception3;
      // ISSUE: fault handler
      try
      {
        counter = new CounterInputStream(@is);
        try
        {
          stream = new DataInputStream((InputStream) counter);
          try
          {
            Vars.logic.reset();
            SaveIO.readHeader((DataInput) stream);
            int key = stream.readInt();
            ((SaveVersion) SaveIO.__\u003C\u003Eversions.get(key)).read(stream, counter, context);
            Events.fire((object) new EventType.SaveLoadEvent());
          }
          catch (Exception ex)
          {
            exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_8;
          }
          ((FilterInputStream) stream).close();
          goto label_36;
        }
        catch (Exception ex)
        {
          exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_9;
        }
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_10;
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
label_8:
      Exception exception4 = exception1;
      Exception exception5;
      Exception exception6;
      Exception exception7;
      Exception exception8;
      // ISSUE: fault handler
      try
      {
        Exception exception9 = exception4;
        try
        {
          exception5 = exception9;
          try
          {
            exception6 = exception5;
            try
            {
              ((FilterInputStream) stream).close();
              goto label_30;
            }
            catch (Exception ex)
            {
              exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
          }
          catch (Exception ex)
          {
            exception7 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            goto label_20;
          }
        }
        catch (Exception ex)
        {
          exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_21;
        }
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception10 = exception5;
      Exception exception11;
      Exception exception12;
      // ISSUE: fault handler
      try
      {
        Exception exception9 = exception10;
        try
        {
          exception11 = exception9;
          try
          {
            Exception exception13 = exception11;
            Throwable.instancehelper_addSuppressed(exception6, exception13);
            goto label_30;
          }
          catch (Exception ex)
          {
            exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (Exception ex)
        {
          exception12 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_29;
        }
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception14 = exception11;
      goto label_40;
label_29:
      Exception exception15 = exception12;
      goto label_59;
label_20:
      exception14 = exception7;
      goto label_40;
label_21:
      exception15 = exception8;
      goto label_59;
label_30:
      Exception exception16;
      Exception exception17;
      // ISSUE: fault handler
      try
      {
        try
        {
          throw Throwable.__\u003Cunmap\u003E(exception6);
        }
        catch (Exception ex)
        {
          exception16 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception17 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_35;
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception14 = exception16;
      goto label_40;
label_35:
      exception15 = exception17;
      goto label_59;
label_9:
      exception14 = exception2;
      goto label_40;
label_10:
      exception15 = exception3;
      goto label_59;
label_36:
      Exception exception18;
      // ISSUE: fault handler
      try
      {
        counter.close();
        goto label_58;
      }
      catch (Exception ex)
      {
        exception18 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception15 = exception18;
      goto label_59;
label_58:
      Vars.world.setGenerating(false);
      Vars.content.setTemporaryMapper((MappableContent[][]) null);
      return;
label_40:
      Exception exception19 = exception14;
      Exception exception20;
      Exception exception21;
      Exception exception22;
      // ISSUE: fault handler
      try
      {
        exception20 = exception19;
        try
        {
          exception21 = exception20;
          try
          {
            counter.close();
            goto label_54;
          }
          catch (Exception ex)
          {
            exception20 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
        }
        catch (Exception ex)
        {
          exception22 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_48;
        }
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      Exception exception23 = exception20;
      Exception exception24;
      // ISSUE: fault handler
      try
      {
        exception24 = exception23;
        try
        {
          Exception exception9 = exception24;
          Throwable.instancehelper_addSuppressed(exception21, exception9);
          goto label_54;
        }
        catch (Exception ex)
        {
          exception24 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception15 = exception24;
      goto label_59;
label_48:
      exception15 = exception22;
      goto label_59;
label_54:
      Exception exception25;
      // ISSUE: fault handler
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception21);
      }
      catch (Exception ex)
      {
        exception25 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
      exception15 = exception25;
label_59:
      Exception exception26 = exception15;
      // ISSUE: fault handler
      try
      {
        Exception throwable = exception26;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new SaveIO.SaveException(throwable);
      }
      __fault
      {
        Vars.world.setGenerating(false);
        Vars.content.setTemporaryMapper((MappableContent[][]) null);
      }
    }

    [LineNumberTable(20)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SaveIO()
    {
    }

    [LineNumberTable(33)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static SaveVersion getSaveWriter() => (SaveVersion) SaveIO.__\u003C\u003EversionArray.peek();

    [LineNumberTable(100)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Fi fileFor(int slot) => Vars.saveDirectory.child(new StringBuilder().append(slot).append(".").append("msav").toString());

    [Throws(new string[] {"mindustry.io.SaveIO$SaveException"})]
    [LineNumberTable(new byte[] {80, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void load(string saveName) => SaveIO.load(Vars.saveDirectory.child(new StringBuilder().append(saveName).append(".msav").toString()));

    [LineNumberTable(new byte[] {159, 137, 141, 127, 0, 106, 191, 17, 127, 0, 114, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SaveIO()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.io.SaveIO"))
        return;
      SaveIO.__\u003C\u003Eheader = new byte[4]
      {
        (byte) 77,
        (byte) 83,
        (byte) 65,
        (byte) 86
      };
      SaveIO.__\u003C\u003Eversions = new IntMap();
      SaveIO.__\u003C\u003EversionArray = Seq.with((object[]) new SaveVersion[4]
      {
        (SaveVersion) new Save1(),
        (SaveVersion) new Save2(),
        (SaveVersion) new Save3(),
        (SaveVersion) new Save4()
      });
      Iterator iterator = SaveIO.__\u003C\u003EversionArray.iterator();
      while (iterator.hasNext())
      {
        SaveVersion saveVersion = (SaveVersion) iterator.next();
        SaveIO.__\u003C\u003Eversions.put(saveVersion.version, (object) saveVersion);
      }
    }

    [Modifiers]
    public static byte[] header
    {
      [HideFromJava] get => SaveIO.__\u003C\u003Eheader;
    }

    [Modifiers]
    public static IntMap versions
    {
      [HideFromJava] get => SaveIO.__\u003C\u003Eversions;
    }

    [Modifiers]
    public static Seq versionArray
    {
      [HideFromJava] get => SaveIO.__\u003C\u003EversionArray;
    }

    public class SaveException : RuntimeException
    {
      [LineNumberTable(new byte[] {160, 70, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public SaveException(Exception throwable)
        : base(throwable)
      {
      }
    }
  }
}
