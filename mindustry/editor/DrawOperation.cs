// Decompiled with JetBrains decompiler
// Type: mindustry.editor.DrawOperation
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.world;
using mindustry.world.blocks.environment;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.editor
{
  public class DrawOperation : Object
  {
    private MapEditor editor;
    private LongSeq array;

    [LineNumberTable(new byte[] {159, 183, 109, 127, 41, 127, 11})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateTile([In] int obj0)
    {
      long tileop = this.array.get(obj0);
      this.array.set(obj0, TileOp.get(TileOp.x(tileop), TileOp.y(tileop), TileOp.type(tileop), this.getTile(this.editor.tile((int) TileOp.x(tileop), (int) TileOp.y(tileop)), TileOp.type(tileop))));
      this.setTile(this.editor.tile((int) TileOp.x(tileop), (int) TileOp.y(tileop)), TileOp.type(tileop), TileOp.value(tileop));
    }

    [LineNumberTable(new byte[] {159, 131, 163, 109, 103, 109, 103, 109, 121, 109, 105, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual short getTile([In] Tile obj0, [In] byte obj1)
    {
      int num = (int) (sbyte) obj1;
      if (num == DrawOperation.OpType.__\u003C\u003Efloor.ordinal())
        return obj0.floorID();
      if (num == DrawOperation.OpType.__\u003C\u003Eblock.ordinal())
        return obj0.blockID();
      if (num == DrawOperation.OpType.__\u003C\u003Erotation.ordinal())
        return obj0.build == null ? (short) 0 : (short) (sbyte) obj0.build.rotation;
      if (num == DrawOperation.OpType.__\u003C\u003Eteam.ordinal())
        return (short) (sbyte) obj0.getTeamID();
      if (num == DrawOperation.OpType.__\u003C\u003Eoverlay.ordinal())
        return obj0.overlayID();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException("Invalid type.");
    }

    [LineNumberTable(new byte[] {159, 127, 133, 249, 82, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void setTile([In] Tile obj0, [In] byte obj1, [In] short obj2)
    {
      int num1 = (int) (sbyte) obj1;
      int num2 = (int) obj2;
      this.editor.load((Runnable) new DrawOperation.__\u003C\u003EAnon0(this, (byte) num1, obj0, (short) num2));
      this.editor.renderer.updatePoint((int) obj0.x, (int) obj0.y);
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 127, 165, 109, 123, 109, 145, 108, 159, 4, 113, 111, 118, 109, 110, 109, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setTile\u00242([In] byte obj0, [In] Tile obj1, [In] short obj2)
    {
      int num = (int) (sbyte) obj0;
      int id = (int) obj2;
      if (num == DrawOperation.OpType.__\u003C\u003Efloor.ordinal())
        obj1.setFloor((Floor) Vars.content.block(id));
      else if (num == DrawOperation.OpType.__\u003C\u003Eblock.ordinal())
      {
        obj1.getLinkedTiles((Cons) new DrawOperation.__\u003C\u003EAnon1(this));
        Block type = Vars.content.block(id);
        obj1.setBlock(type, obj1.team(), obj1.build != null ? obj1.build.rotation : 0);
        obj1.getLinkedTiles((Cons) new DrawOperation.__\u003C\u003EAnon2(this));
      }
      else if (num == DrawOperation.OpType.__\u003C\u003Erotation.ordinal())
      {
        if (obj1.build == null)
          return;
        obj1.build.rotation = id;
      }
      else if (num == DrawOperation.OpType.__\u003C\u003Eteam.ordinal())
      {
        obj1.setTeam(Team.get(id));
      }
      else
      {
        if (num != DrawOperation.OpType.__\u003C\u003Eoverlay.ordinal())
          return;
        obj1.setOverlayID((short) id);
      }
    }

    [Modifiers]
    [LineNumberTable(66)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setTile\u00240([In] Tile obj0) => this.editor.renderer.updatePoint((int) obj0.x, (int) obj0.y);

    [Modifiers]
    [LineNumberTable(71)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024setTile\u00241([In] Tile obj0) => this.editor.renderer.updatePoint((int) obj0.x, (int) obj0.y);

    [LineNumberTable(new byte[] {159, 158, 8, 171, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public DrawOperation(MapEditor editor)
    {
      DrawOperation drawOperation = this;
      this.array = new LongSeq();
      this.editor = editor;
    }

    [LineNumberTable(21)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isEmpty() => this.array.isEmpty();

    [LineNumberTable(new byte[] {159, 167, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addOperation(long op) => this.array.add(op);

    [LineNumberTable(new byte[] {159, 171, 114, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void undo()
    {
      for (int index = this.array.size - 1; index >= 0; index += -1)
        this.updateTile(index);
    }

    [LineNumberTable(new byte[] {159, 177, 112, 39, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void redo()
    {
      for (int index = 0; index < this.array.size; ++index)
        this.updateTile(index);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Lmindustry/editor/DrawOperation$OpType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class OpType : Enum
    {
      [Modifiers]
      internal static DrawOperation.OpType __\u003C\u003Efloor;
      [Modifiers]
      internal static DrawOperation.OpType __\u003C\u003Eblock;
      [Modifiers]
      internal static DrawOperation.OpType __\u003C\u003Erotation;
      [Modifiers]
      internal static DrawOperation.OpType __\u003C\u003Eteam;
      [Modifiers]
      internal static DrawOperation.OpType __\u003C\u003Eoverlay;
      [Modifiers]
      private static DrawOperation.OpType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(91)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private OpType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(91)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static DrawOperation.OpType[] values() => (DrawOperation.OpType[]) DrawOperation.OpType.\u0024VALUES.Clone();

      [LineNumberTable(91)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static DrawOperation.OpType valueOf(string name) => (DrawOperation.OpType) Enum.valueOf((Class) ClassLiteral<DrawOperation.OpType>.Value, name);

      [LineNumberTable(new byte[] {159, 119, 77, 112, 112, 112, 112, 240, 59})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static OpType()
      {
        if (ByteCodeHelper.isAlreadyInited("mindustry.editor.DrawOperation$OpType"))
          return;
        DrawOperation.OpType.__\u003C\u003Efloor = new DrawOperation.OpType(nameof (floor), 0);
        DrawOperation.OpType.__\u003C\u003Eblock = new DrawOperation.OpType(nameof (block), 1);
        DrawOperation.OpType.__\u003C\u003Erotation = new DrawOperation.OpType(nameof (rotation), 2);
        DrawOperation.OpType.__\u003C\u003Eteam = new DrawOperation.OpType(nameof (team), 3);
        DrawOperation.OpType.__\u003C\u003Eoverlay = new DrawOperation.OpType(nameof (overlay), 4);
        DrawOperation.OpType.\u0024VALUES = new DrawOperation.OpType[5]
        {
          DrawOperation.OpType.__\u003C\u003Efloor,
          DrawOperation.OpType.__\u003C\u003Eblock,
          DrawOperation.OpType.__\u003C\u003Erotation,
          DrawOperation.OpType.__\u003C\u003Eteam,
          DrawOperation.OpType.__\u003C\u003Eoverlay
        };
      }

      [Modifiers]
      public static DrawOperation.OpType floor
      {
        [HideFromJava] get => DrawOperation.OpType.__\u003C\u003Efloor;
      }

      [Modifiers]
      public static DrawOperation.OpType block
      {
        [HideFromJava] get => DrawOperation.OpType.__\u003C\u003Eblock;
      }

      [Modifiers]
      public static DrawOperation.OpType rotation
      {
        [HideFromJava] get => DrawOperation.OpType.__\u003C\u003Erotation;
      }

      [Modifiers]
      public static DrawOperation.OpType team
      {
        [HideFromJava] get => DrawOperation.OpType.__\u003C\u003Eteam;
      }

      [Modifiers]
      public static DrawOperation.OpType overlay
      {
        [HideFromJava] get => DrawOperation.OpType.__\u003C\u003Eoverlay;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        floor,
        block,
        rotation,
        team,
        overlay,
      }
    }

    internal class TileOpStruct : Object
    {
      internal short x;
      internal short y;
      internal byte type;
      internal short value;
      [Modifiers]
      internal DrawOperation this\u00240;

      [LineNumberTable(84)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal TileOpStruct([In] DrawOperation obj0)
      {
        this.this\u00240 = obj0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      private readonly DrawOperation arg\u00241;
      private readonly byte arg\u00242;
      private readonly Tile arg\u00243;
      private readonly short arg\u00244;

      internal __\u003C\u003EAnon0([In] DrawOperation obj0, [In] byte obj1, [In] Tile obj2, [In] short obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void run() => this.arg\u00241.lambda\u0024setTile\u00242(this.arg\u00242, this.arg\u00243, this.arg\u00244);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Cons
    {
      private readonly DrawOperation arg\u00241;

      internal __\u003C\u003EAnon1([In] DrawOperation obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setTile\u00240((Tile) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Cons
    {
      private readonly DrawOperation arg\u00241;

      internal __\u003C\u003EAnon2([In] DrawOperation obj0) => this.arg\u00241 = obj0;

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024setTile\u00241((Tile) obj0);
    }
  }
}
