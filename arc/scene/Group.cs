// Decompiled with JetBrains decompiler
// Type: arc.scene.Group
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.graphics.g2d;
using arc.math;
using arc.math.geom;
using arc.scene.@event;
using arc.scene.style;
using arc.scene.ui.layout;
using arc.scene.utils;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.scene
{
  [Implements(new string[] {"arc.scene.utils.Cullable"})]
  public abstract class Group : Element, Cullable
  {
    [Modifiers]
    private static Vec2 tmp;
    [Signature("Larc/struct/SnapshotSeq<Larc/scene/Element;>;")]
    internal SnapshotSeq __\u003C\u003Echildren;
    [Modifiers]
    private Affine2 worldTransform;
    [Modifiers]
    private Mat computedTransform;
    [Modifiers]
    private Mat oldTransform;
    protected internal bool transform;
    protected internal Rect cullingArea;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 61, 130, 113, 99, 103, 138, 103, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeChild(Element actor, bool unfocus)
    {
      int num = unfocus ? 1 : 0;
      if (!this.__\u003C\u003Echildren.remove((object) actor, true))
        return false;
      if (num != 0)
        this.getScene()?.unfocus(actor);
      actor.parent = (Group) null;
      actor.setScene((Scene) null);
      this.childrenChanged();
      return true;
    }

    [LineNumberTable(new byte[] {88, 103, 110, 127, 12, 187, 103, 99, 106, 137, 144, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual Mat computeTransform()
    {
      Affine2 worldTransform = this.worldTransform;
      float originX = this.originX;
      float originY = this.originY;
      worldTransform.setToTrnRotScl(this.x + originX, this.y + originY, this.rotation, this.scaleX, this.scaleY);
      if ((double) originX != 0.0 || (double) originY != 0.0)
        worldTransform.translate(-originX, -originY);
      Group parent = this.parent;
      while (parent != null && !parent.transform)
        parent = parent.parent;
      if (parent != null)
        worldTransform.preMul(parent.worldTransform);
      this.computedTransform.set(worldTransform);
      return this.computedTransform;
    }

    [LineNumberTable(new byte[] {110, 113, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void applyTransform(Mat transform)
    {
      this.oldTransform.set(Draw.trans());
      Draw.trans(transform);
    }

    [LineNumberTable(new byte[] {6, 121, 103, 108, 103, 134, 103, 107, 104, 108, 107, 116, 102, 109, 110, 114, 123, 123, 127, 19, 103, 123, 251, 54, 240, 78, 112, 107, 107, 116, 102, 109, 110, 114, 127, 19, 123, 123, 103, 105, 233, 54, 235, 77, 104, 136, 133, 107, 116, 102, 109, 110, 123, 123, 103, 123, 251, 56, 240, 76, 111, 107, 107, 116, 102, 109, 110, 114, 122, 123, 103, 105, 233, 55, 235, 75, 103, 168, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void drawChildren()
    {
      this.parentAlpha *= this.__\u003C\u003Ecolor.a;
      SnapshotSeq children = this.__\u003C\u003Echildren;
      Element[] elementArray = (Element[]) children.begin();
      Rect cullingArea = this.cullingArea;
      if (cullingArea != null)
      {
        float x1 = cullingArea.x;
        float num1 = x1 + cullingArea.width;
        float y1 = cullingArea.y;
        float num2 = y1 + cullingArea.height;
        if (this.transform)
        {
          int index = 0;
          for (int size = children.size; index < size; ++index)
          {
            Element element = elementArray[index];
            element.parentAlpha = this.parentAlpha;
            if (element.visible)
            {
              float x2 = element.x;
              float y2 = element.y;
              element.x += element.translation.x;
              element.y += element.translation.y;
              if ((double) x2 <= (double) num1 && (double) y2 <= (double) num2 && ((double) (x2 + element.width) >= (double) x1 && (double) (y2 + element.height) >= (double) y1) || !element.cullable)
                element.draw();
              element.x -= element.translation.x;
              element.y -= element.translation.y;
            }
          }
        }
        else
        {
          float x2 = this.x;
          float y2 = this.y;
          this.x = 0.0f;
          this.y = 0.0f;
          int index = 0;
          for (int size = children.size; index < size; ++index)
          {
            Element element = elementArray[index];
            element.parentAlpha = this.parentAlpha;
            if (element.visible)
            {
              float x3 = element.x;
              float y3 = element.y;
              if ((double) x3 <= (double) num1 && (double) y3 <= (double) num2 && ((double) (x3 + element.width) >= (double) x1 && (double) (y3 + element.height) >= (double) y1) || !element.cullable)
              {
                element.x = x3 + x2 + element.translation.x;
                element.y = y3 + y2 + element.translation.y;
                element.draw();
                element.x = x3;
                element.y = y3;
              }
            }
          }
          this.x = x2;
          this.y = y2;
        }
      }
      else if (this.transform)
      {
        int index = 0;
        for (int size = children.size; index < size; ++index)
        {
          Element element = elementArray[index];
          element.parentAlpha = this.parentAlpha;
          if (element.visible)
          {
            element.x += element.translation.x;
            element.y += element.translation.y;
            element.draw();
            element.x -= element.translation.x;
            element.y -= element.translation.y;
          }
        }
      }
      else
      {
        float x1 = this.x;
        float y1 = this.y;
        this.x = 0.0f;
        this.y = 0.0f;
        int index = 0;
        for (int size = children.size; index < size; ++index)
        {
          Element element = elementArray[index];
          element.parentAlpha = this.parentAlpha;
          if (element.visible)
          {
            float x2 = element.x;
            float y2 = element.y;
            element.x = x2 + x1 + element.translation.x;
            element.y = y2 + y1 + element.translation.y;
            element.draw();
            element.x = x2;
            element.y = y2;
          }
        }
        this.x = x1;
        this.y = y1;
      }
      children.end();
    }

    [LineNumberTable(new byte[] {119, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void resetTransform() => Draw.trans(this.oldTransform);

    [Signature("()Larc/struct/SnapshotSeq<Larc/scene/Element;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual SnapshotSeq getChildren() => this.__\u003C\u003Echildren;

    [Signature("(Larc/func/Cons<Larc/scene/Element;>;)V")]
    [LineNumberTable(new byte[] {160, 97, 127, 1, 103, 104, 140, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void forEach(Cons cons)
    {
      Iterator iterator = this.getChildren().iterator();
      while (iterator.hasNext())
      {
        Element element = (Element) iterator.next();
        cons.get((object) element);
        if (element is Group)
          ((Group) element).forEach(cons);
      }
    }

    [LineNumberTable(new byte[] {160, 135, 104, 111, 142, 108, 103, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChild(Element actor)
    {
      if (actor.parent != null)
      {
        if (object.ReferenceEquals((object) actor.parent, (object) this))
          return;
        actor.parent.removeChild(actor, false);
      }
      this.__\u003C\u003Echildren.add((object) actor);
      actor.parent = this;
      actor.setScene(this.getScene());
      this.childrenChanged();
    }

    [Signature("(Larc/scene/style/Drawable;Larc/func/Cons<Larc/scene/ui/layout/Table;>;)V")]
    [LineNumberTable(new byte[] {160, 124, 113, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fill(Drawable background, Cons cons)
    {
      Table table = background != null ? new Table(background) : new Table();
      table.setFillParent(true);
      this.addChild((Element) table);
      cons.get((object) table);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void childrenChanged()
    {
    }

    [LineNumberTable(new byte[] {160, 225, 113, 114, 100, 103, 231, 61, 230, 69, 107, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void clearChildren()
    {
      Element[] elementArray = (Element[]) this.__\u003C\u003Echildren.begin();
      int index = 0;
      for (int size = this.__\u003C\u003Echildren.size; index < size; ++index)
      {
        Element element = elementArray[index];
        element.setScene((Scene) null);
        element.parent = (Group) null;
      }
      this.__\u003C\u003Echildren.end();
      this.__\u003C\u003Echildren.clear();
      this.childrenChanged();
    }

    [Signature("<T:Larc/scene/Element;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {160, 249, 103, 109, 63, 7, 134, 109, 109, 104, 110, 231, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element find(string name)
    {
      SnapshotSeq children = this.__\u003C\u003Echildren;
      int index1 = 0;
      for (int size = children.size; index1 < size; ++index1)
      {
        if (String.instancehelper_equals(name, (object) ((Element) children.get(index1)).name))
          return (Element) children.get(index1);
      }
      int index2 = 0;
      for (int size = children.size; index2 < size; ++index2)
      {
        Element element1 = (Element) children.get(index2);
        if (element1 is Group)
        {
          Element element2 = ((Group) element1).find(name);
          if (element2 != null)
            return element2;
        }
      }
      return (Element) null;
    }

    [Signature("<T:Larc/scene/Element;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {161, 9, 103, 109, 63, 26, 134, 109, 109, 112, 110, 231, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element findVisible(string name)
    {
      SnapshotSeq children = this.__\u003C\u003Echildren;
      int index1 = 0;
      for (int size = children.size; index1 < size; ++index1)
      {
        if (String.instancehelper_equals(name, (object) ((Element) children.get(index1)).name) && ((Element) children.get(index1)).visible)
          return (Element) children.get(index1);
      }
      int index2 = 0;
      for (int size = children.size; index2 < size; ++index2)
      {
        Element element = (Element) children.get(index2);
        if (element is Group && element.visible)
        {
          Element visible = ((Group) element).findVisible(name);
          if (visible != null)
            return visible;
        }
      }
      return (Element) null;
    }

    [Signature("<T:Larc/scene/Element;>(Larc/func/Boolf<Larc/scene/Element;>;)TT;")]
    [LineNumberTable(new byte[] {161, 25, 103, 109, 63, 2, 166, 109, 109, 104, 110, 231, 60, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element find(Boolf pred)
    {
      SnapshotSeq children = this.__\u003C\u003Echildren;
      int index1 = 0;
      for (int size = children.size; index1 < size; ++index1)
      {
        if (pred.get((object) (Element) children.get(index1)))
          return (Element) children.get(index1);
      }
      int index2 = 0;
      for (int size = children.size; index2 < size; ++index2)
      {
        Element element1 = (Element) children.get(index2);
        if (element1 is Group)
        {
          Element element2 = ((Group) element1).find(pred);
          if (element2 != null)
            return element2;
        }
      }
      return (Element) null;
    }

    [LineNumberTable(new byte[] {161, 91, 103, 159, 9, 146, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 localToDescendantCoordinates(Element descendant, Vec2 localCoords)
    {
      Group parent = descendant.parent;
      if (parent == null)
      {
        string str = new StringBuilder().append("Child is not a descendant: ").append((object) descendant).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      if (!object.ReferenceEquals((object) parent, (object) this))
        this.localToDescendantCoordinates((Element) parent, localCoords);
      descendant.parentToLocalCoordinates(localCoords);
      return localCoords;
    }

    [LineNumberTable(new byte[] {161, 110, 109, 137, 113, 117, 102, 44, 134, 101, 105, 146, 105, 233, 56, 233, 75, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void toString([In] StringBuilder obj0, [In] int obj1)
    {
      obj0.append(base.toString());
      obj0.append('\n');
      Element[] elementArray = (Element[]) this.__\u003C\u003Echildren.begin();
      int index1 = 0;
      for (int size = this.__\u003C\u003Echildren.size; index1 < size; ++index1)
      {
        for (int index2 = 0; index2 < obj1; ++index2)
          obj0.append("|  ");
        Element element = elementArray[index1];
        if (element is Group)
        {
          ((Group) element).toString(obj0, obj1 + 1);
        }
        else
        {
          obj0.append((object) element);
          obj0.append('\n');
        }
      }
      this.__\u003C\u003Echildren.end();
    }

    [LineNumberTable(new byte[] {159, 167, 168, 114, 107, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Group()
    {
      Group group = this;
      this.__\u003C\u003Echildren = new SnapshotSeq(true, 4, (Class) ClassLiteral<Element>.Value);
      this.worldTransform = new Affine2();
      this.computedTransform = new Mat();
      this.oldTransform = new Mat();
      this.transform = false;
    }

    [LineNumberTable(new byte[] {159, 179, 104, 113, 114, 106, 138, 232, 60, 230, 70, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void act(float delta)
    {
      base.act(delta);
      Element[] elementArray = (Element[]) this.__\u003C\u003Echildren.begin();
      int index = 0;
      for (int size = this.__\u003C\u003Echildren.size; index < size; ++index)
      {
        if (elementArray[index].visible)
          elementArray[index].act(delta);
        elementArray[index].updateVisibility();
      }
      this.__\u003C\u003Echildren.end();
    }

    [LineNumberTable(new byte[] {0, 116, 102, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void draw()
    {
      if (this.transform)
        this.applyTransform(this.computeTransform());
      this.drawChildren();
      if (!this.transform)
        return;
      this.resetTransform();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect getCullingArea() => this.cullingArea;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCullingArea(Rect cullingArea) => this.cullingArea = cullingArea;

    [LineNumberTable(new byte[] {159, 94, 66, 119, 102, 113, 114, 101, 107, 114, 118, 231, 59, 230, 71})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override Element hit(float x, float y, bool touchable)
    {
      int num = touchable ? 1 : 0;
      if (num != 0 && object.ReferenceEquals((object) this.touchable, (object) Touchable.__\u003C\u003Edisabled))
        return (Element) null;
      Vec2 tmp = Group.tmp;
      Element[] items = (Element[]) this.__\u003C\u003Echildren.items;
      for (int index = this.__\u003C\u003Echildren.size - 1; index >= 0; index += -1)
      {
        Element element1 = items[index];
        if (element1.visible)
        {
          element1.parentToLocalCoordinates(tmp.set(x, y));
          Element element2 = element1.hit(tmp.x, tmp.y, num != 0);
          if (element2 != null)
            return element2;
        }
      }
      return base.hit(x, y, num != 0);
    }

    [LineNumberTable(new byte[] {160, 106, 232, 70, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Element fill(Table.DrawRect rect)
    {
      Group.\u0031 obj = new Group.\u0031(this, rect);
      obj.setFillParent(true);
      this.addChild((Element) obj);
      return (Element) obj;
    }

    [Signature("(Larc/func/Cons<Larc/scene/ui/layout/Table;>;)V")]
    [LineNumberTable(new byte[] {160, 119, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void fill(Cons cons) => this.fill((Drawable) null, cons);

    [LineNumberTable(new byte[] {160, 151, 104, 111, 142, 110, 142, 109, 103, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildAt(int index, Element actor)
    {
      if (actor.parent != null)
      {
        if (object.ReferenceEquals((object) actor.parent, (object) this))
          return;
        actor.parent.removeChild(actor, false);
      }
      if (index >= this.__\u003C\u003Echildren.size)
        this.__\u003C\u003Echildren.add((object) actor);
      else
        this.__\u003C\u003Echildren.insert(index, (object) actor);
      actor.parent = this;
      actor.setScene(this.getScene());
      this.childrenChanged();
    }

    [LineNumberTable(new byte[] {160, 169, 104, 111, 142, 110, 109, 103, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildBefore(Element actorBefore, Element actor)
    {
      if (actor.parent != null)
      {
        if (object.ReferenceEquals((object) actor.parent, (object) this))
          return;
        actor.parent.removeChild(actor, false);
      }
      this.__\u003C\u003Echildren.insert(this.__\u003C\u003Echildren.indexOf((object) actorBefore, true), (object) actor);
      actor.parent = this;
      actor.setScene(this.getScene());
      this.childrenChanged();
    }

    [LineNumberTable(new byte[] {160, 185, 104, 111, 142, 110, 110, 142, 111, 103, 108, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addChildAfter(Element actorAfter, Element actor)
    {
      if (actor.parent != null)
      {
        if (object.ReferenceEquals((object) actor.parent, (object) this))
          return;
        actor.parent.removeChild(actor, false);
      }
      int num = this.__\u003C\u003Echildren.indexOf((object) actorAfter, true);
      if (num == this.__\u003C\u003Echildren.size)
        this.__\u003C\u003Echildren.add((object) actor);
      else
        this.__\u003C\u003Echildren.insert(num + 1, (object) actor);
      actor.parent = this;
      actor.setScene(this.getScene());
      this.childrenChanged();
    }

    [LineNumberTable(315)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool removeChild(Element actor) => this.removeChild(actor, true);

    [LineNumberTable(new byte[] {160, 239, 102, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void clear()
    {
      base.clear();
      this.clearChildren();
    }

    [LineNumberTable(new byte[] {161, 41, 103, 113, 114, 41, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal override void setScene(Scene stage)
    {
      base.setScene(stage);
      Element[] items = (Element[]) this.__\u003C\u003Echildren.items;
      int index = 0;
      for (int size = this.__\u003C\u003Echildren.size; index < size; ++index)
        items[index].setScene(stage);
    }

    [LineNumberTable(new byte[] {161, 49, 108, 106, 106, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool swapActor(int first, int second)
    {
      int size = this.__\u003C\u003Echildren.size;
      if (first < 0 || first >= size || (second < 0 || second >= size))
        return false;
      this.__\u003C\u003Echildren.swap(first, second);
      return true;
    }

    [LineNumberTable(new byte[] {161, 58, 110, 110, 106, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool swapActor(Element first, Element second)
    {
      int first1 = this.__\u003C\u003Echildren.indexOf((object) first, true);
      int second1 = this.__\u003C\u003Echildren.indexOf((object) second, true);
      if (first1 == -1 || second1 == -1)
        return false;
      this.__\u003C\u003Echildren.swap(first1, second1);
      return true;
    }

    [LineNumberTable(441)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool hasChildren() => this.__\u003C\u003Echildren.size > 0;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isTransform() => this.transform;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setTransform(bool transform) => this.transform = transform;

    [LineNumberTable(new byte[] {161, 103, 107, 104, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public override string toString()
    {
      StringBuilder stringBuilder = new StringBuilder(128);
      this.toString(stringBuilder, 1);
      stringBuilder.setLength(stringBuilder.length() - 1);
      return stringBuilder.toString();
    }

    [LineNumberTable(26)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Group()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.scene.Group"))
        return;
      Group.tmp = new Vec2();
    }

    [Modifiers]
    protected internal SnapshotSeq children
    {
      [HideFromJava] get => this.__\u003C\u003Echildren;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Echildren = value;
    }

    [EnclosingMethod(null, "fill", "(Larc.scene.ui.layout.Table$DrawRect;)Larc.scene.Element;")]
    [SpecialName]
    internal new class \u0031 : Element
    {
      [Modifiers]
      internal Table.DrawRect val\u0024rect;
      [Modifiers]
      internal Group this\u00240;

      [LineNumberTable(220)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] Group obj0, [In] Table.DrawRect obj1)
      {
        this.this\u00240 = obj0;
        this.val\u0024rect = obj1;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 109, 127, 4})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void draw() => this.val\u0024rect.draw(this.x, this.y, this.width, this.height);
    }
  }
}
