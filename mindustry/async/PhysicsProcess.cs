// Decompiled with JetBrains decompiler
// Type: mindustry.async.PhysicsProcess
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.math;
using arc.math.geom;
using ikvm.@internal;
using IKVM.Attributes;
using java.lang;
using java.util;
using mindustry.entities;
using mindustry.gen;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.async
{
  public class PhysicsProcess : Object, AsyncProcess
  {
    private const int layers = 3;
    private const int layerGround = 0;
    private const int layerLegs = 1;
    private const int layerFlying = 2;
    private PhysicsProcess.PhysicsWorld physics;
    [Signature("Larc/struct/Seq<Lmindustry/async/PhysicsProcess$PhysicRef;>;")]
    private Seq refs;
    [Signature("Lmindustry/entities/EntityGroup<Lmindustry/gen/Unit;>;")]
    private EntityGroup group;

    [LineNumberTable(new byte[] {159, 154, 232, 72, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public PhysicsProcess()
    {
      PhysicsProcess physicsProcess = this;
      this.refs = new Seq(false);
      this.group = Groups.unit;
    }

    [LineNumberTable(new byte[] {47, 104, 108, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void reset()
    {
      if (this.physics == null)
        return;
      this.refs.clear();
      this.physics = (PhysicsProcess.PhysicsWorld) null;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {159, 172, 109, 113, 108, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool lambda\u0024begin\u00240([In] PhysicsProcess.PhysicRef obj0)
    {
      if (obj0.entity.isAdded())
        return false;
      this.physics.remove(obj0.body);
      obj0.entity.physref((PhysicsProcess.PhysicRef) null);
      return true;
    }

    [LineNumberTable(new byte[] {159, 168, 169, 247, 74, 127, 4, 138, 107, 102, 109, 109, 109, 148, 104, 140, 135, 204, 136, 103, 112, 113, 110, 110, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void begin()
    {
      if (this.physics == null)
        return;
      this.refs.removeAll((Boolf) new PhysicsProcess.__\u003C\u003EAnon0(this));
      Iterator iterator = this.group.iterator();
      while (iterator.hasNext())
      {
        Unit unit = (Unit) iterator.next();
        if (unit.type != null)
        {
          if (unit.physref == null)
          {
            PhysicsProcess.PhysicsWorld.PhysicsBody body = new PhysicsProcess.PhysicsWorld.PhysicsBody();
            body.x = unit.x();
            body.y = unit.y();
            body.mass = unit.mass();
            body.radius = unit.hitSize() / 2f;
            PhysicsProcess.PhysicRef physicRef = new PhysicsProcess.PhysicRef((Physicsc) unit, body);
            this.refs.add((object) physicRef);
            unit.physref = physicRef;
            this.physics.add(body);
          }
          PhysicsProcess.PhysicRef physref = unit.physref;
          physref.body.layer = !unit.type.allowLegStep ? (!unit.isGrounded() ? 2 : 0) : 1;
          physref.x = unit.x();
          physref.y = unit.y();
        }
      }
    }

    [LineNumberTable(new byte[] {20, 169, 159, 1, 113, 113, 130, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void process()
    {
      if (this.physics == null)
        return;
      Iterator iterator = this.refs.iterator();
      while (iterator.hasNext())
      {
        PhysicsProcess.PhysicRef physicRef = (PhysicsProcess.PhysicRef) iterator.next();
        physicRef.body.x = physicRef.x;
        physicRef.body.y = physicRef.y;
      }
      this.physics.update();
    }

    [LineNumberTable(new byte[] {34, 169, 127, 1, 167, 127, 13, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void end()
    {
      if (this.physics == null)
        return;
      Iterator iterator = this.refs.iterator();
      while (iterator.hasNext())
      {
        PhysicsProcess.PhysicRef physicRef = (PhysicsProcess.PhysicRef) iterator.next();
        physicRef.entity.move(physicRef.body.x - physicRef.x, physicRef.body.y - physicRef.y);
      }
    }

    [LineNumberTable(new byte[] {55, 134, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void init()
    {
      this.reset();
      this.physics = new PhysicsProcess.PhysicsWorld(Vars.world.getQuadBounds(new Rect()));
    }

    [HideFromJava]
    public virtual bool shouldProcess() => AsyncProcess.\u003Cdefault\u003EshouldProcess((AsyncProcess) this);

    public class PhysicRef : Object
    {
      public Physicsc entity;
      public PhysicsProcess.PhysicsWorld.PhysicsBody body;
      public float x;
      public float y;

      [LineNumberTable(new byte[] {65, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PhysicRef(Physicsc entity, PhysicsProcess.PhysicsWorld.PhysicsBody body)
      {
        PhysicsProcess.PhysicRef physicRef = this;
        this.entity = entity;
        this.body = body;
      }
    }

    public class PhysicsWorld : Object
    {
      private const float scl = 1.25f;
      [Modifiers]
      [Signature("[Larc/math/geom/QuadTree<Lmindustry/async/PhysicsProcess$PhysicsWorld$PhysicsBody;>;")]
      private QuadTree[] trees;
      [Modifiers]
      [Signature("Larc/struct/Seq<Lmindustry/async/PhysicsProcess$PhysicsWorld$PhysicsBody;>;")]
      private Seq bodies;
      [Modifiers]
      [Signature("Larc/struct/Seq<Lmindustry/async/PhysicsProcess$PhysicsWorld$PhysicsBody;>;")]
      private Seq seq;
      [Modifiers]
      private Rect rect;
      [Modifiers]
      private Vec2 vec;

      [LineNumberTable(new byte[] {89, 108})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void add(PhysicsProcess.PhysicsWorld.PhysicsBody body) => this.bodies.add((object) body);

      [LineNumberTable(new byte[] {97, 102, 45, 198, 112, 115, 103, 243, 61, 230, 70, 115, 115, 140, 108, 158, 115, 147, 153, 112, 159, 1, 105, 127, 20, 112, 152, 127, 5, 127, 5, 127, 5, 255, 5, 48, 233, 83, 231, 38, 233, 92})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void update()
      {
        for (int index = 0; index < 3; ++index)
          this.trees[index].clear();
        for (int index = 0; index < this.bodies.size; ++index)
        {
          PhysicsProcess.PhysicsWorld.PhysicsBody physicsBody = ((PhysicsProcess.PhysicsWorld.PhysicsBody[]) this.bodies.items)[index];
          physicsBody.collided = false;
          this.trees[physicsBody.layer].insert((QuadTree.QuadTreeObject) physicsBody);
        }
        for (int index1 = 0; index1 < this.bodies.size; ++index1)
        {
          PhysicsProcess.PhysicsWorld.PhysicsBody physicsBody1 = ((PhysicsProcess.PhysicsWorld.PhysicsBody[]) this.bodies.items)[index1];
          physicsBody1.hitbox(this.rect);
          this.seq.size = 0;
          this.trees[physicsBody1.layer].intersect(this.rect, this.seq);
          for (int index2 = 0; index2 < this.seq.size; ++index2)
          {
            PhysicsProcess.PhysicsWorld.PhysicsBody physicsBody2 = ((PhysicsProcess.PhysicsWorld.PhysicsBody[]) this.seq.items)[index2];
            if (!object.ReferenceEquals((object) physicsBody2, (object) physicsBody1) && !physicsBody2.collided)
            {
              float num1 = physicsBody1.radius + physicsBody2.radius;
              float num2 = Mathf.dst(physicsBody1.x, physicsBody1.y, physicsBody2.x, physicsBody2.y);
              if ((double) num2 < (double) num1)
              {
                this.vec.set(physicsBody1.x - physicsBody2.x, physicsBody1.y - physicsBody2.y).setLength(num1 - num2);
                float num3 = physicsBody1.mass + physicsBody2.mass;
                float num4 = physicsBody2.mass / num3;
                float num5 = physicsBody1.mass / num3;
                physicsBody1.x += this.vec.x * num4 / 1.25f;
                physicsBody1.y += this.vec.y * num4 / 1.25f;
                physicsBody2.x -= this.vec.x * num5 / 1.25f;
                physicsBody2.y -= this.vec.y * num5 / 1.25f;
              }
            }
          }
          physicsBody1.collided = true;
        }
      }

      [LineNumberTable(new byte[] {82, 232, 58, 108, 115, 112, 107, 171, 102, 51, 166})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public PhysicsWorld(Rect bounds)
      {
        PhysicsProcess.PhysicsWorld physicsWorld = this;
        this.trees = new QuadTree[3];
        this.bodies = new Seq(false, 16, (Class) ClassLiteral<PhysicsProcess.PhysicsWorld.PhysicsBody>.Value);
        this.seq = new Seq((Class) ClassLiteral<PhysicsProcess.PhysicsWorld.PhysicsBody>.Value);
        this.rect = new Rect();
        this.vec = new Vec2();
        for (int index = 0; index < 3; ++index)
          this.trees[index] = new QuadTree(new Rect(bounds));
      }

      [LineNumberTable(new byte[] {93, 109})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual void remove(PhysicsProcess.PhysicsWorld.PhysicsBody body) => this.bodies.remove((object) body);

      public class PhysicsBody : Object, QuadTree.QuadTreeObject
      {
        public float x;
        public float y;
        public float radius;
        public float mass;
        public int layer;
        public bool collided;

        [LineNumberTable(new byte[] {160, 73, 136, 103})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public PhysicsBody()
        {
          PhysicsProcess.PhysicsWorld.PhysicsBody physicsBody = this;
          this.layer = 0;
          this.collided = false;
        }

        [LineNumberTable(new byte[] {160, 80, 127, 14})]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public virtual void hitbox(Rect @out) => @out.setCentered(this.x, this.y, this.radius * 2f, this.radius * 2f);
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Boolf
    {
      private readonly PhysicsProcess arg\u00241;

      internal __\u003C\u003EAnon0([In] PhysicsProcess obj0) => this.arg\u00241 = obj0;

      public bool get([In] object obj0) => (this.arg\u00241.lambda\u0024begin\u00240((PhysicsProcess.PhysicRef) obj0) ? 1 : 0) != 0;
    }
  }
}
