// Decompiled with JetBrains decompiler
// Type: mindustry.io.SaveFileReader
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.util.io;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using mindustry.world;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.io
{
  public abstract class SaveFileReader : Object
  {
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;")]
    internal static ObjectMap __\u003C\u003Efallback;
    internal ReusableByteOutStream __\u003C\u003EbyteOutput;
    internal DataOutputStream __\u003C\u003EdataBytes;
    internal ReusableByteOutStream __\u003C\u003EbyteOutputSmall;
    internal DataOutputStream __\u003C\u003EdataBytesSmall;
    protected internal int lastRegionLength;
    [arc.util.Nullable(new object[] {64, "Larc/util/Nullable;"})]
    protected internal CounterInputStream currCounter;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/lang/String;Ljava/io/DataInput;Larc/util/io/CounterInputStream;Lmindustry/io/SaveFileReader$IORunner<Ljava/io/DataInput;>;)V")]
    [LineNumberTable(new byte[] {17, 102, 167, 188, 2, 97, 191, 17, 107, 159, 45})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void region(
      string name,
      DataInput stream,
      CounterInputStream counter,
      SaveFileReader.IORunner cons)
    {
      counter.resetCount();
      this.currCounter = counter;
      int num;
      Exception exception1;
      try
      {
        num = this.readChunk(stream, cons);
        goto label_5;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      string str1 = new StringBuilder().append("Error reading region \"").append(name).append("\".").toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException(str1, exception3);
label_5:
      if (num != counter.count - 4)
      {
        string str2 = new StringBuilder().append("Error reading region \"").append(name).append("\": read length mismatch. Expected: ").append(num).append("; Actual: ").append(counter.count - 4).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str2);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {97, 102, 103, 102, 51, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual StringMap readStringMap(DataInput stream)
    {
      StringMap stringMap = new StringMap();
      int num = (int) stream.readShort();
      for (int index = 0; index < num; ++index)
        stringMap.put((object) stream.readUTF(), (object) stream.readUTF());
      return stringMap;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/io/DataInput;Lmindustry/io/SaveFileReader$IORunner<Ljava/io/DataInput;>;)I")]
    [LineNumberTable(114)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readChunk(DataInput input, SaveFileReader.IORunner runner) => this.readChunk(input, false, runner);

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/io/DataOutput;Lmindustry/io/SaveFileReader$IORunner<Ljava/io/DataOutput;>;)V")]
    [LineNumberTable(new byte[] {40, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeChunk(DataOutput output, SaveFileReader.IORunner runner) => this.writeChunk(output, false, runner);

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/io/DataOutput;ZLmindustry/io/SaveFileReader$IORunner<Ljava/io/DataOutput;>;)V")]
    [LineNumberTable(new byte[] {159, 119, 162, 146, 134, 119, 135, 99, 137, 104, 159, 26, 135, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeChunk(DataOutput output, bool isByte, SaveFileReader.IORunner runner)
    {
      int num1 = isByte ? 1 : 0;
      ReusableByteOutStream reusableByteOutStream = num1 == 0 ? this.__\u003C\u003EbyteOutput : this.__\u003C\u003EbyteOutputSmall;
      reusableByteOutStream.reset();
      runner.accept(num1 == 0 ? (object) this.__\u003C\u003EdataBytes : (object) this.__\u003C\u003EdataBytesSmall);
      int num2 = reusableByteOutStream.size();
      if (num1 == 0)
      {
        output.writeInt(num2);
      }
      else
      {
        if (num2 > (int) short.MaxValue)
        {
          string str = new StringBuilder().append("Byte write length exceeded: ").append(num2).append(" > ").append((int) short.MaxValue).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IOException(str);
        }
        output.writeShort(num2);
      }
      output.write(reusableByteOutStream.getBytes(), 0, num2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/io/DataInput;ZLmindustry/io/SaveFileReader$IORunner<Ljava/io/DataInput;>;)I")]
    [LineNumberTable(new byte[] {159, 113, 162, 114, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int readChunk(DataInput input, bool isShort, SaveFileReader.IORunner runner)
    {
      int num = !isShort ? input.readInt() : input.readUnsignedShort();
      this.lastRegionLength = num;
      runner.accept((object) input);
      return num;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 110, 162, 115, 104, 100, 159, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void skipChunk(DataInput input, bool isByte)
    {
      int num1 = isByte ? 1 : 0;
      int num2 = this.readChunk(input, num1 != 0, (SaveFileReader.IORunner) new SaveFileReader.__\u003C\u003EAnon0());
      int num3 = input.skipBytes(num2);
      if (num2 != num3)
      {
        string str = new StringBuilder().append("Could not skip bytes. Expected length: ").append(num2).append("; Actual length: ").append(num3).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IOException(str);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024skipChunk\u00240([In] DataInput obj0)
    {
    }

    [LineNumberTable(new byte[] {159, 153, 232, 111, 107, 113, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SaveFileReader()
    {
      SaveFileReader saveFileReader = this;
      this.__\u003C\u003EbyteOutput = new ReusableByteOutStream();
      this.__\u003C\u003EdataBytes = new DataOutputStream((OutputStream) this.__\u003C\u003EbyteOutput);
      this.__\u003C\u003EbyteOutputSmall = new ReusableByteOutStream();
      this.__\u003C\u003EdataBytesSmall = new DataOutputStream((OutputStream) this.__\u003C\u003EbyteOutputSmall);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/lang/String;Ljava/io/DataOutput;Lmindustry/io/SaveFileReader$IORunner<Ljava/io/DataOutput;>;)V")]
    [LineNumberTable(new byte[] {33, 186, 2, 97, 159, 17})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void region(string name, DataOutput stream, SaveFileReader.IORunner cons)
    {
      Exception exception1;
      try
      {
        this.writeChunk(stream, cons);
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      string str = new StringBuilder().append("Error writing region \"").append(name).append("\".").toString();
      Exception exception3 = exception2;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IOException(str, exception3);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {76, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void skipChunk(DataInput input) => this.skipChunk(input, false);

    [Throws(new string[] {"java.io.IOException"})]
    [Signature("(Ljava/io/DataOutput;Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/String;>;)V")]
    [LineNumberTable(new byte[] {89, 108, 127, 1, 113, 113, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void writeStringMap(DataOutput stream, ObjectMap map)
    {
      stream.writeShort(map.size);
      ObjectMap.Entries entries = map.entries().iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        stream.writeUTF((string) entry.key);
        stream.writeUTF((string) entry.value);
      }
    }

    [Throws(new string[] {"java.io.IOException"})]
    public abstract void read(DataInputStream dis, CounterInputStream cis, WorldContext wc);

    [Throws(new string[] {"java.io.IOException"})]
    public abstract void write(DataOutputStream dos);

    [LineNumberTable(12)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static SaveFileReader()
    {
      if (ByteCodeHelper.isAlreadyInited("mindustry.io.SaveFileReader"))
        return;
      SaveFileReader.__\u003C\u003Efallback = ObjectMap.of((object) "dart-mech-pad", (object) "legacy-mech-pad", (object) "dart-ship-pad", (object) "legacy-mech-pad", (object) "javelin-ship-pad", (object) "legacy-mech-pad", (object) "trident-ship-pad", (object) "legacy-mech-pad", (object) "glaive-ship-pad", (object) "legacy-mech-pad", (object) "alpha-mech-pad", (object) "legacy-mech-pad", (object) "tau-mech-pad", (object) "legacy-mech-pad", (object) "omega-mech-pad", (object) "legacy-mech-pad", (object) "delta-mech-pad", (object) "legacy-mech-pad", (object) "draug-factory", (object) "legacy-unit-factory", (object) "spirit-factory", (object) "legacy-unit-factory", (object) "phantom-factory", (object) "legacy-unit-factory", (object) "wraith-factory", (object) "legacy-unit-factory", (object) "ghoul-factory", (object) "legacy-unit-factory-air", (object) "revenant-factory", (object) "legacy-unit-factory-air", (object) "dagger-factory", (object) "legacy-unit-factory", (object) "crawler-factory", (object) "legacy-unit-factory", (object) "titan-factory", (object) "legacy-unit-factory-ground", (object) "fortress-factory", (object) "legacy-unit-factory-ground", (object) "mass-conveyor", (object) "payload-conveyor", (object) "vestige", (object) "scepter", (object) "turbine-generator", (object) "steam-generator", (object) "rocks", (object) "stone-wall", (object) "sporerocks", (object) "spore-wall", (object) "icerocks", (object) "ice-wall", (object) "dunerocks", (object) "dune-wall", (object) "sandrocks", (object) "sand-wall", (object) "shalerocks", (object) "shale-wall", (object) "snowrocks", (object) "snow-wall", (object) "saltrocks", (object) "salt-wall", (object) "dirtwall", (object) "dirt-wall", (object) "ignarock", (object) "basalt", (object) "holostone", (object) "dacite", (object) "holostone-wall", (object) "dacite-wall", (object) "rock", (object) "boulder", (object) "snowrock", (object) "snow-boulder", (object) "cliffs", (object) "stone-wall", (object) "cryofluidmixer", (object) "cryofluid-mixer");
    }

    [Modifiers]
    public static ObjectMap fallback
    {
      [HideFromJava] get => SaveFileReader.__\u003C\u003Efallback;
    }

    [Modifiers]
    protected internal ReusableByteOutStream byteOutput
    {
      [HideFromJava] get => this.__\u003C\u003EbyteOutput;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EbyteOutput = value;
    }

    [Modifiers]
    protected internal DataOutputStream dataBytes
    {
      [HideFromJava] get => this.__\u003C\u003EdataBytes;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EdataBytes = value;
    }

    [Modifiers]
    protected internal ReusableByteOutStream byteOutputSmall
    {
      [HideFromJava] get => this.__\u003C\u003EbyteOutputSmall;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EbyteOutputSmall = value;
    }

    [Modifiers]
    protected internal DataOutputStream dataBytesSmall
    {
      [HideFromJava] get => this.__\u003C\u003EdataBytesSmall;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EdataBytesSmall = value;
    }

    [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
    public interface IORunner
    {
      [Throws(new string[] {"java.io.IOException"})]
      [Signature("(TT;)V")]
      void accept(object obj);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : SaveFileReader.IORunner
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void accept([In] object obj0) => SaveFileReader.lambda\u0024skipChunk\u00240((DataInput) obj0);
    }
  }
}
