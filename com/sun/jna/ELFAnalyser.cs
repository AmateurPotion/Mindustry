// Decompiled with JetBrains decompiler
// Type: com.sun.jna.ELFAnalyser
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.nio;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace com.sun.jna
{
  internal class ELFAnalyser : Object
  {
    [Modifiers]
    private static byte[] ELF_MAGIC;
    private const int EF_ARM_ABI_FLOAT_HARD = 1024;
    private const int EF_ARM_ABI_FLOAT_SOFT = 512;
    private const int EI_DATA_BIG_ENDIAN = 2;
    private const int E_MACHINE_ARM = 40;
    private const int EI_CLASS_64BIT = 2;
    [Modifiers]
    private string filename;
    private bool ELF;
    private bool _64Bit;
    private bool bigEndian;
    private bool armHardFloat;
    private bool armSoftFloat;
    private bool arm;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {52, 232, 3, 103, 103, 103, 103, 103, 231, 121, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private ELFAnalyser([In] string obj0)
    {
      ELFAnalyser elfAnalyser = this;
      this.ELF = false;
      this._64Bit = false;
      this.bigEndian = false;
      this.armHardFloat = false;
      this.armSoftFloat = false;
      this.arm = false;
      this.filename = obj0;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {59, 118, 106, 103, 104, 104, 109, 167, 104, 129, 168, 104, 106, 104, 116, 111, 113, 155, 147, 104, 118, 117, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void runDetection()
    {
      RandomAccessFile.__\u003Cclinit\u003E();
      RandomAccessFile randomAccessFile = new RandomAccessFile(this.filename, "r");
      if (randomAccessFile.length() > 4L)
      {
        byte[] numArray = new byte[4];
        randomAccessFile.seek(0L);
        randomAccessFile.read(numArray);
        if (Arrays.equals(numArray, ELFAnalyser.ELF_MAGIC))
          this.ELF = true;
      }
      if (!this.ELF)
        return;
      randomAccessFile.seek(4L);
      this._64Bit = randomAccessFile.readByte() == (byte) 2;
      randomAccessFile.seek(0L);
      ByteBuffer byteBuffer = ByteBuffer.allocate(!this._64Bit ? 52 : 64);
      randomAccessFile.getChannel().read(byteBuffer, 0L);
      this.bigEndian = byteBuffer.get(5) == (byte) 2;
      byteBuffer.order(!this.bigEndian ? (ByteOrder) ByteOrder.LITTLE_ENDIAN : (ByteOrder) ByteOrder.BIG_ENDIAN);
      this.arm = byteBuffer.get(18) == (byte) 40;
      if (!this.arm)
        return;
      int num = byteBuffer.getInt(!this._64Bit ? 36 : 48);
      this.armSoftFloat = (num & 512) == 512;
      this.armHardFloat = (num & 1024) == 1024;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {159, 177, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static ELFAnalyser analyse([In] string obj0)
    {
      ELFAnalyser elfAnalyser = new ELFAnalyser(obj0);
      elfAnalyser.runDetection();
      return elfAnalyser;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isELF() => this.ELF;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool is64Bit() => this._64Bit;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isBigEndian() => this.bigEndian;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getFilename() => this.filename;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isArmHardFloat() => this.armHardFloat;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isArmSoftFloat() => this.armSoftFloat;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isArm() => this.arm;

    [LineNumberTable(19)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static ELFAnalyser()
    {
      if (ByteCodeHelper.isAlreadyInited("com.sun.jna.ELFAnalyser"))
        return;
      ELFAnalyser.ELF_MAGIC = new byte[4]
      {
        (byte) 127,
        (byte) 69,
        (byte) 76,
        (byte) 70
      };
    }
  }
}
