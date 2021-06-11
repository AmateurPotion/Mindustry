// Decompiled with JetBrains decompiler
// Type: net.jpountz.lz4.LZ4HCJavaUnsafeCompressor
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.nio;
using java.util;
using net.jpountz.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace net.jpountz.lz4
{
  internal sealed class LZ4HCJavaUnsafeCompressor : LZ4Compressor
  {
    [Modifiers]
    public static LZ4Compressor INSTANCE;
    [Modifiers]
    private int maxAttempts;
    [Modifiers]
    internal int compressionLevel;
    [Modifiers]
    internal static bool \u0024assertionsDisabled;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [Modifiers]
    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static int access\u0024000([In] LZ4HCJavaUnsafeCompressor obj0) => obj0.maxAttempts;

    [LineNumberTable(new byte[] {159, 168, 104, 110, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4HCJavaUnsafeCompressor([In] int obj0)
    {
      LZ4HCJavaUnsafeCompressor unsafeCompressor = this;
      this.maxAttempts = 1 << obj0 - 1;
      this.compressionLevel = obj0;
    }

    [LineNumberTable(new byte[] {160, 149, 104, 139, 100, 102, 101, 132, 99, 100, 138, 105, 103, 103, 103, 167, 104, 111, 102, 194, 201, 125, 191, 17, 127, 5, 108, 165, 112, 120, 169, 159, 3, 114, 105, 229, 69, 118, 105, 102, 132, 117, 155, 116, 101, 201, 191, 26, 112, 182, 127, 5, 139, 127, 5, 108, 165, 117, 115, 112, 113, 105, 106, 201, 127, 5, 139, 105, 137, 165, 105, 197, 115, 115, 107, 137, 114, 152, 113, 105, 98, 214, 127, 5, 139, 105, 137, 229, 71, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int compress(
      [In] byte[] obj0,
      [In] int obj1,
      [In] int obj2,
      [In] byte[] obj3,
      [In] int obj4,
      [In] int obj5)
    {
      UnsafeUtils.checkRange(obj0, obj1, obj2);
      UnsafeUtils.checkRange(obj3, obj4, obj5);
      int num1 = obj1 + obj2;
      int num2 = obj4 + obj5;
      int num3 = num1 - 12;
      int num4 = num1 - 5;
      int num5 = obj1;
      int num6 = obj4;
      int num7 = num5;
      int num8 = num5 + 1;
      int num9 = num7;
      LZ4HCJavaUnsafeCompressor.HashTable hashTable = new LZ4HCJavaUnsafeCompressor.HashTable(this, obj1);
      LZ4Utils.Match match1 = new LZ4Utils.Match();
      LZ4Utils.Match match2 = new LZ4Utils.Match();
      LZ4Utils.Match match3 = new LZ4Utils.Match();
      LZ4Utils.Match match4 = new LZ4Utils.Match();
label_1:
      while (num8 < num3)
      {
        if (!hashTable.insertAndFindBestMatch(obj0, num8, num4, match2))
        {
          ++num8;
        }
        else
        {
          LZ4Utils.copyTo(match2, match1);
          while (LZ4HCJavaUnsafeCompressor.\u0024assertionsDisabled || match2.start >= num9)
          {
            if (match2.end() >= num3 || !hashTable.insertAndFindWiderMatch(obj0, match2.end() - 2, match2.start + 1, num4, match2.len, match3))
            {
              num6 = LZ4UnsafeUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
              num9 = num8 = match2.end();
              goto label_1;
            }
            else
            {
              if (match1.start < match2.start && match3.start < match2.start + match1.len)
                LZ4Utils.copyTo(match1, match2);
              if (!LZ4HCJavaUnsafeCompressor.\u0024assertionsDisabled && match3.start <= match2.start)
              {
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new AssertionError();
              }
              if (match3.start - match2.start < 3)
              {
                LZ4Utils.copyTo(match3, match2);
              }
              else
              {
                while (true)
                {
                  if (match3.start - match2.start < 18)
                  {
                    int num10 = match2.len;
                    if (num10 > 18)
                      num10 = 18;
                    if (match2.start + num10 > match3.end() - 4)
                      num10 = match3.start - match2.start + match3.len - 4;
                    int num11 = num10 - (match3.start - match2.start);
                    if (num11 > 0)
                      match3.fix(num11);
                  }
                  if (match3.start + match3.len < num3 && hashTable.insertAndFindWiderMatch(obj0, match3.end() - 3, match3.start, num4, match3.len, match4))
                  {
                    if (match4.start < match2.end() + 3)
                    {
                      if (match4.start < match2.end())
                        LZ4Utils.copyTo(match4, match3);
                      else
                        goto label_28;
                    }
                    else
                    {
                      if (match3.start < match2.end())
                      {
                        if (match3.start - match2.start < 15)
                        {
                          if (match2.len > 18)
                            match2.len = 18;
                          if (match2.end() > match3.end() - 4)
                            match2.len = match3.end() - match2.start - 4;
                          int num10 = match2.end() - match3.start;
                          match3.fix(num10);
                        }
                        else
                          match2.len = match3.start - match2.start;
                      }
                      num6 = LZ4UnsafeUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
                      num9 = match2.end();
                      LZ4Utils.copyTo(match3, match2);
                      LZ4Utils.copyTo(match4, match3);
                    }
                  }
                  else
                    break;
                }
                if (match3.start < match2.end())
                  match2.len = match3.start - match2.start;
                int num12 = LZ4UnsafeUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
                int num13 = match2.end();
                num6 = LZ4UnsafeUtils.encodeSequence(obj0, num13, match3.start, match3.@ref, match3.len, obj3, num12, num2);
                num9 = num8 = match3.end();
                goto label_1;
label_28:
                if (match3.start < match2.end())
                {
                  int num10 = match2.end() - match3.start;
                  match3.fix(num10);
                  if (match3.len < 4)
                    LZ4Utils.copyTo(match4, match3);
                }
                num6 = LZ4UnsafeUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
                num9 = match2.end();
                LZ4Utils.copyTo(match4, match2);
                LZ4Utils.copyTo(match3, match1);
              }
            }
          }
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
      }
      return LZ4UnsafeUtils.lastLiterals(obj0, num9, num1 - num9, obj3, num6, num2) - obj4;
    }

    [LineNumberTable(25)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal LZ4HCJavaUnsafeCompressor()
      : this(9)
    {
    }

    [LineNumberTable(new byte[] {161, 35, 113, 159, 10, 104, 137, 104, 139, 100, 102, 101, 132, 99, 100, 138, 105, 103, 103, 103, 167, 104, 111, 102, 194, 201, 125, 191, 17, 127, 5, 108, 165, 112, 120, 169, 159, 3, 114, 105, 229, 69, 118, 105, 102, 132, 117, 155, 116, 101, 201, 191, 26, 112, 182, 127, 5, 139, 127, 5, 108, 165, 117, 115, 112, 113, 105, 106, 201, 127, 5, 139, 105, 137, 165, 105, 197, 115, 115, 107, 137, 114, 152, 113, 105, 98, 214, 127, 5, 139, 105, 137, 229, 71, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override int compress(
      [In] ByteBuffer obj0,
      [In] int obj1,
      [In] int obj2,
      [In] ByteBuffer obj3,
      [In] int obj4,
      [In] int obj5)
    {
      if (obj0.hasArray() && obj3.hasArray())
        return this.compress(obj0.array(), obj1 + obj0.arrayOffset(), obj2, obj3.array(), obj4 + obj3.arrayOffset(), obj5);
      obj0 = ByteBufferUtils.inNativeByteOrder(obj0);
      obj3 = ByteBufferUtils.inNativeByteOrder(obj3);
      ByteBufferUtils.checkRange(obj0, obj1, obj2);
      ByteBufferUtils.checkRange(obj3, obj4, obj5);
      int num1 = obj1 + obj2;
      int num2 = obj4 + obj5;
      int num3 = num1 - 12;
      int num4 = num1 - 5;
      int num5 = obj1;
      int num6 = obj4;
      int num7 = num5;
      int num8 = num5 + 1;
      int num9 = num7;
      LZ4HCJavaUnsafeCompressor.HashTable hashTable = new LZ4HCJavaUnsafeCompressor.HashTable(this, obj1);
      LZ4Utils.Match match1 = new LZ4Utils.Match();
      LZ4Utils.Match match2 = new LZ4Utils.Match();
      LZ4Utils.Match match3 = new LZ4Utils.Match();
      LZ4Utils.Match match4 = new LZ4Utils.Match();
label_3:
      while (num8 < num3)
      {
        if (!hashTable.insertAndFindBestMatch(obj0, num8, num4, match2))
        {
          ++num8;
        }
        else
        {
          LZ4Utils.copyTo(match2, match1);
          while (LZ4HCJavaUnsafeCompressor.\u0024assertionsDisabled || match2.start >= num9)
          {
            if (match2.end() >= num3 || !hashTable.insertAndFindWiderMatch(obj0, match2.end() - 2, match2.start + 1, num4, match2.len, match3))
            {
              num6 = LZ4ByteBufferUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
              num9 = num8 = match2.end();
              goto label_3;
            }
            else
            {
              if (match1.start < match2.start && match3.start < match2.start + match1.len)
                LZ4Utils.copyTo(match1, match2);
              if (!LZ4HCJavaUnsafeCompressor.\u0024assertionsDisabled && match3.start <= match2.start)
              {
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new AssertionError();
              }
              if (match3.start - match2.start < 3)
              {
                LZ4Utils.copyTo(match3, match2);
              }
              else
              {
                while (true)
                {
                  if (match3.start - match2.start < 18)
                  {
                    int num10 = match2.len;
                    if (num10 > 18)
                      num10 = 18;
                    if (match2.start + num10 > match3.end() - 4)
                      num10 = match3.start - match2.start + match3.len - 4;
                    int num11 = num10 - (match3.start - match2.start);
                    if (num11 > 0)
                      match3.fix(num11);
                  }
                  if (match3.start + match3.len < num3 && hashTable.insertAndFindWiderMatch(obj0, match3.end() - 3, match3.start, num4, match3.len, match4))
                  {
                    if (match4.start < match2.end() + 3)
                    {
                      if (match4.start < match2.end())
                        LZ4Utils.copyTo(match4, match3);
                      else
                        goto label_30;
                    }
                    else
                    {
                      if (match3.start < match2.end())
                      {
                        if (match3.start - match2.start < 15)
                        {
                          if (match2.len > 18)
                            match2.len = 18;
                          if (match2.end() > match3.end() - 4)
                            match2.len = match3.end() - match2.start - 4;
                          int num10 = match2.end() - match3.start;
                          match3.fix(num10);
                        }
                        else
                          match2.len = match3.start - match2.start;
                      }
                      num6 = LZ4ByteBufferUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
                      num9 = match2.end();
                      LZ4Utils.copyTo(match3, match2);
                      LZ4Utils.copyTo(match4, match3);
                    }
                  }
                  else
                    break;
                }
                if (match3.start < match2.end())
                  match2.len = match3.start - match2.start;
                int num12 = LZ4ByteBufferUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
                int num13 = match2.end();
                num6 = LZ4ByteBufferUtils.encodeSequence(obj0, num13, match3.start, match3.@ref, match3.len, obj3, num12, num2);
                num9 = num8 = match3.end();
                goto label_3;
label_30:
                if (match3.start < match2.end())
                {
                  int num10 = match2.end() - match3.start;
                  match3.fix(num10);
                  if (match3.len < 4)
                    LZ4Utils.copyTo(match4, match3);
                }
                num6 = LZ4ByteBufferUtils.encodeSequence(obj0, num9, match2.start, match2.@ref, match2.len, obj3, num6, num2);
                num9 = match2.end();
                LZ4Utils.copyTo(match4, match2);
                LZ4Utils.copyTo(match3, match1);
              }
            }
          }
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError();
        }
      }
      return LZ4ByteBufferUtils.lastLiterals(obj0, num9, num1 - num9, obj3, num6, num2) - obj4;
    }

    [LineNumberTable(new byte[] {159, 138, 141, 149})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static LZ4HCJavaUnsafeCompressor()
    {
      if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4HCJavaUnsafeCompressor"))
        return;
      LZ4HCJavaUnsafeCompressor.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4HCJavaUnsafeCompressor>.Value).desiredAssertionStatus();
      LZ4HCJavaUnsafeCompressor.INSTANCE = (LZ4Compressor) new LZ4HCJavaUnsafeCompressor();
    }

    [InnerClass]
    internal class HashTable : Object
    {
      internal const int MASK = 65535;
      internal int nextToUpdate;
      [Modifiers]
      private int @base;
      [Modifiers]
      private int[] hashTable;
      [Modifiers]
      private short[] chainTable;
      [Modifiers]
      internal static bool \u0024assertionsDisabled;
      [Modifiers]
      internal LZ4HCJavaUnsafeCompressor this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [LineNumberTable(new byte[] {7, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int hashPointer([In] int obj0) => this.hashTable[LZ4Utils.hashHC(obj0)];

      [LineNumberTable(new byte[] {26, 103, 107, 119, 104, 134, 112, 105})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void addHash([In] int obj0, [In] int obj1)
      {
        int index = LZ4Utils.hashHC(obj0);
        int num1 = obj1 - this.hashTable[index];
        if (!LZ4HCJavaUnsafeCompressor.HashTable.\u0024assertionsDisabled && num1 <= 0)
        {
          int num2 = num1;
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new AssertionError(num2);
        }
        if (num1 >= 65536)
          num1 = (int) ushort.MaxValue;
        this.chainTable[obj1 & (int) ushort.MaxValue] = (short) num1;
        this.hashTable[index] = obj1;
      }

      [LineNumberTable(new byte[] {16, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void addHash([In] byte[] obj0, [In] int obj1) => this.addHash(UnsafeUtils.readInt(obj0, obj1), obj1);

      [LineNumberTable(new byte[] {21, 104, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void addHash([In] ByteBuffer obj0, [In] int obj1) => this.addHash(ByteBufferUtils.readInt(obj0, obj1), obj1);

      [LineNumberTable(new byte[] {37, 105, 45, 176})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void insert([In] int obj0, [In] byte[] obj1)
      {
        for (; this.nextToUpdate < obj0; ++this.nextToUpdate)
          this.addHash(obj1, this.nextToUpdate);
      }

      [LineNumberTable(new byte[] {159, 189, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int hashPointer([In] byte[] obj0, [In] int obj1) => this.hashPointer(UnsafeUtils.readInt(obj0, obj1));

      [LineNumberTable(62)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int next([In] int obj0) => obj0 - ((int) this.chainTable[obj0 & (int) ushort.MaxValue] & (int) ushort.MaxValue);

      [LineNumberTable(new byte[] {43, 105, 45, 176})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual void insert([In] int obj0, [In] ByteBuffer obj1)
      {
        for (; this.nextToUpdate < obj0; ++this.nextToUpdate)
          this.addHash(obj1, this.nextToUpdate);
      }

      [LineNumberTable(new byte[] {2, 104})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private int hashPointer([In] ByteBuffer obj0, [In] int obj1) => this.hashPointer(ByteBufferUtils.readInt(obj0, obj1));

      [LineNumberTable(new byte[] {159, 180, 111, 103, 103, 112, 108, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal HashTable([In] LZ4HCJavaUnsafeCompressor obj0, [In] int obj1)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        LZ4HCJavaUnsafeCompressor.HashTable hashTable = this;
        this.@base = obj1;
        this.nextToUpdate = obj1;
        this.hashTable = new int[32768];
        Arrays.fill(this.hashTable, -1);
        this.chainTable = new short[65536];
      }

      [LineNumberTable(new byte[] {51, 104, 104, 98, 130, 136, 137, 118, 106, 100, 126, 136, 168, 117, 123, 130, 106, 113, 107, 104, 169, 232, 53, 235, 78, 102, 99, 103, 104, 113, 168, 113, 118, 102, 102, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool insertAndFindBestMatch(
        [In] byte[] obj0,
        [In] int obj1,
        [In] int obj2,
        [In] LZ4Utils.Match obj3)
      {
        obj3.start = obj1;
        obj3.len = 0;
        int num1 = 0;
        int num2 = 0;
        this.insert(obj1, obj0);
        int num3 = this.hashPointer(obj0, obj1);
        if (num3 >= obj1 - 4 && num3 <= obj1 && num3 >= this.@base)
        {
          if (LZ4UnsafeUtils.readIntEquals(obj0, num3, obj1))
          {
            num1 = obj1 - num3;
            LZ4Utils.Match match1 = obj3;
            int num4 = 4 + LZ4UnsafeUtils.commonBytes(obj0, num3 + 4, obj1 + 4, obj2);
            LZ4Utils.Match match2 = match1;
            int num5 = num4;
            match2.len = num4;
            num2 = num5;
            obj3.@ref = num3;
          }
          num3 = this.next(num3);
        }
        for (int index = 0; index < LZ4HCJavaUnsafeCompressor.access\u0024000(this.this\u00240) && num3 >= Math.max(this.@base, obj1 - 65536 + 1) && num3 <= obj1; ++index)
        {
          if (LZ4UnsafeUtils.readIntEquals(obj0, num3, obj1))
          {
            int num4 = 4 + LZ4UnsafeUtils.commonBytes(obj0, num3 + 4, obj1 + 4, obj2);
            if (num4 > obj3.len)
            {
              obj3.@ref = num3;
              obj3.len = num4;
            }
          }
          num3 = this.next(num3);
        }
        if (num2 != 0)
        {
          int srcOff = obj1;
          int num4;
          for (num4 = obj1 + num2 - 3; srcOff < num4 - num1; ++srcOff)
            this.chainTable[srcOff & (int) ushort.MaxValue] = (short) num1;
          do
          {
            this.chainTable[srcOff & (int) ushort.MaxValue] = (short) num1;
            this.hashTable[LZ4Utils.hashHC(UnsafeUtils.readInt(obj0, srcOff))] = srcOff;
            ++srcOff;
          }
          while (srcOff < num4);
          this.nextToUpdate = num4;
        }
        return obj3.len != 0;
      }

      [LineNumberTable(new byte[] {102, 137, 136, 100, 105, 115, 126, 133, 106, 113, 112, 101, 107, 105, 106, 170, 232, 50, 233, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool insertAndFindWiderMatch(
        [In] byte[] obj0,
        [In] int obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] LZ4Utils.Match obj5)
      {
        obj5.len = obj4;
        this.insert(obj1, obj0);
        int num1 = obj1 - obj2;
        int num2 = this.hashPointer(obj0, obj1);
        for (int index = 0; index < LZ4HCJavaUnsafeCompressor.access\u0024000(this.this\u00240) && num2 >= Math.max(this.@base, obj1 - 65536 + 1) && num2 <= obj1; ++index)
        {
          if (LZ4UnsafeUtils.readIntEquals(obj0, num2, obj1))
          {
            int num3 = 4 + LZ4UnsafeUtils.commonBytes(obj0, num2 + 4, obj1 + 4, obj3);
            int num4 = LZ4UnsafeUtils.commonBytesBackward(obj0, num2, obj1, this.@base, obj2);
            int num5 = num4 + num3;
            if (num5 > obj5.len)
            {
              obj5.len = num5;
              obj5.@ref = num2 - num4;
              obj5.start = obj1 - num4;
            }
          }
          num2 = this.next(num2);
        }
        return obj5.len > obj4;
      }

      [LineNumberTable(new byte[] {160, 66, 104, 104, 98, 130, 136, 137, 118, 106, 100, 126, 136, 168, 117, 123, 130, 106, 113, 107, 104, 169, 232, 53, 235, 78, 102, 99, 103, 104, 113, 168, 113, 118, 102, 102, 168})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool insertAndFindBestMatch(
        [In] ByteBuffer obj0,
        [In] int obj1,
        [In] int obj2,
        [In] LZ4Utils.Match obj3)
      {
        obj3.start = obj1;
        obj3.len = 0;
        int num1 = 0;
        int num2 = 0;
        this.insert(obj1, obj0);
        int num3 = this.hashPointer(obj0, obj1);
        if (num3 >= obj1 - 4 && num3 <= obj1 && num3 >= this.@base)
        {
          if (LZ4ByteBufferUtils.readIntEquals(obj0, num3, obj1))
          {
            num1 = obj1 - num3;
            LZ4Utils.Match match1 = obj3;
            int num4 = 4 + LZ4ByteBufferUtils.commonBytes(obj0, num3 + 4, obj1 + 4, obj2);
            LZ4Utils.Match match2 = match1;
            int num5 = num4;
            match2.len = num4;
            num2 = num5;
            obj3.@ref = num3;
          }
          num3 = this.next(num3);
        }
        for (int index = 0; index < LZ4HCJavaUnsafeCompressor.access\u0024000(this.this\u00240) && num3 >= Math.max(this.@base, obj1 - 65536 + 1) && num3 <= obj1; ++index)
        {
          if (LZ4ByteBufferUtils.readIntEquals(obj0, num3, obj1))
          {
            int num4 = 4 + LZ4ByteBufferUtils.commonBytes(obj0, num3 + 4, obj1 + 4, obj2);
            if (num4 > obj3.len)
            {
              obj3.@ref = num3;
              obj3.len = num4;
            }
          }
          num3 = this.next(num3);
        }
        if (num2 != 0)
        {
          int i = obj1;
          int num4;
          for (num4 = obj1 + num2 - 3; i < num4 - num1; ++i)
            this.chainTable[i & (int) ushort.MaxValue] = (short) num1;
          do
          {
            this.chainTable[i & (int) ushort.MaxValue] = (short) num1;
            this.hashTable[LZ4Utils.hashHC(ByteBufferUtils.readInt(obj0, i))] = i;
            ++i;
          }
          while (i < num4);
          this.nextToUpdate = num4;
        }
        return obj3.len != 0;
      }

      [LineNumberTable(new byte[] {160, 117, 137, 136, 100, 105, 115, 126, 133, 106, 113, 112, 101, 107, 105, 106, 170, 232, 50, 233, 81})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal virtual bool insertAndFindWiderMatch(
        [In] ByteBuffer obj0,
        [In] int obj1,
        [In] int obj2,
        [In] int obj3,
        [In] int obj4,
        [In] LZ4Utils.Match obj5)
      {
        obj5.len = obj4;
        this.insert(obj1, obj0);
        int num1 = obj1 - obj2;
        int num2 = this.hashPointer(obj0, obj1);
        for (int index = 0; index < LZ4HCJavaUnsafeCompressor.access\u0024000(this.this\u00240) && num2 >= Math.max(this.@base, obj1 - 65536 + 1) && num2 <= obj1; ++index)
        {
          if (LZ4ByteBufferUtils.readIntEquals(obj0, num2, obj1))
          {
            int num3 = 4 + LZ4ByteBufferUtils.commonBytes(obj0, num2 + 4, obj1 + 4, obj3);
            int num4 = LZ4ByteBufferUtils.commonBytesBackward(obj0, num2, obj1, this.@base, obj2);
            int num5 = num4 + num3;
            if (num5 > obj5.len)
            {
              obj5.len = num5;
              obj5.@ref = num2 - num4;
              obj5.start = obj1 - num4;
            }
          }
          num2 = this.next(num2);
        }
        return obj5.len > obj4;
      }

      [LineNumberTable(31)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static HashTable()
      {
        if (ByteCodeHelper.isAlreadyInited("net.jpountz.lz4.LZ4HCJavaUnsafeCompressor$HashTable"))
          return;
        LZ4HCJavaUnsafeCompressor.HashTable.\u0024assertionsDisabled = !((Class) ClassLiteral<LZ4HCJavaUnsafeCompressor>.Value).desiredAssertionStatus();
      }
    }
  }
}
