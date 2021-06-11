// Decompiled with JetBrains decompiler
// Type: arc.math.geom.Rect
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.math.geom
{
  public class Rect : Object, Shape2D
  {
    internal static Rect __\u003C\u003Etmp;
    internal static Rect __\u003C\u003Etmp2;
    private const long serialVersionUID = 5733252015138115702;
    public float x;
    public float y;
    public float width;
    public float height;

    [SpecialName]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void __\u003Cclinit\u003E()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rect()
    {
    }

    [LineNumberTable(55)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setCentered(float x, float y, float width, float height) => this.set(x - width / 2f, y - height / 2f, width, height);

    [LineNumberTable(new byte[] {159, 185, 104, 108, 108, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rect(Rect rect)
    {
      Rect rect1 = this;
      this.x = rect.x;
      this.y = rect.y;
      this.width = rect.width;
      this.height = rect.height;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setSize(float sizeXY)
    {
      this.width = sizeXY;
      this.height = sizeXY;
      return this;
    }

    [LineNumberTable(new byte[] {161, 20, 127, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setCenter(float x, float y)
    {
      this.setPosition(x - this.width / 2f, y - this.height / 2f);
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(float x, float y) => (double) this.x <= (double) x && (double) (this.x + this.width) >= (double) x && ((double) this.y <= (double) y && (double) (this.y + this.height) >= (double) y);

    [LineNumberTable(281)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect grow(float amount) => this.grow(amount, amount);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float area() => this.width * this.height;

    [LineNumberTable(51)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setCentered(float x, float y, float size) => this.set(x - size / 2f, y - size / 2f, size, size);

    [LineNumberTable(256)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool overlaps(Rect r) => (double) this.x < (double) (r.x + r.width) && (double) (this.x + this.width) > (double) r.x && ((double) this.y < (double) (r.y + r.height) && (double) (this.y + this.height) > (double) r.y);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setSize(float width, float height)
    {
      this.width = width;
      this.height = height;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect set(float x, float y, float width, float height)
    {
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setPosition(float x, float y)
    {
      this.x = x;
      this.y = y;
      return this;
    }

    [LineNumberTable(new byte[] {161, 8, 123, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 getCenter(Vec2 vector)
    {
      vector.x = this.x + this.width / 2f;
      vector.y = this.y + this.height / 2f;
      return vector;
    }

    [LineNumberTable(new byte[] {160, 184, 115, 127, 4, 103, 138, 115, 127, 4, 103, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect merge(Rect rect)
    {
      float num1 = Math.min(this.x, rect.x);
      float num2 = Math.max(this.x + this.width, rect.x + rect.width);
      this.x = num1;
      this.width = num2 - num1;
      float num3 = Math.min(this.y, rect.y);
      float num4 = Math.max(this.y + this.height, rect.y + rect.height);
      this.y = num3;
      this.height = num4 - num3;
      return this;
    }

    [LineNumberTable(new byte[] {159, 174, 104, 104, 104, 104, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Rect(float x, float y, float width, float height)
    {
      Rect rect = this;
      this.x = x;
      this.y = y;
      this.width = width;
      this.height = height;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool overlaps(float rx, float ry, float rwidth, float rheight) => (double) this.x < (double) (rx + rwidth) && (double) (this.x + this.width) > (double) rx && ((double) this.y < (double) (ry + rheight) && (double) (this.y + this.height) > (double) ry);

    [LineNumberTable(224)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Vec2 point) => this.contains(point.x, point.y);

    [LineNumberTable(new byte[] {161, 129, 107, 101, 117, 103, 126, 126, 126})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool equals(object obj)
    {
      if (object.ReferenceEquals((object) this, obj))
        return true;
      if (obj == null || !object.ReferenceEquals((object) ((object) this).GetType(), (object) obj.GetType()))
        return false;
      Rect rect = (Rect) obj;
      FloatConverter floatConverter;
      return FloatConverter.ToInt(this.height, ref floatConverter) == FloatConverter.ToInt(rect.height, ref floatConverter) && FloatConverter.ToInt(this.width, ref floatConverter) == FloatConverter.ToInt(rect.width, ref floatConverter) && FloatConverter.ToInt(this.x, ref floatConverter) == FloatConverter.ToInt(rect.x, ref floatConverter) && FloatConverter.ToInt(this.y, ref floatConverter) == FloatConverter.ToInt(rect.y, ref floatConverter);
    }

    [LineNumberTable(new byte[] {160, 127, 103, 138, 103, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Rect rect)
    {
      float x = rect.x;
      float num1 = x + rect.width;
      float y = rect.y;
      float num2 = y + rect.height;
      return (double) x > (double) this.x && (double) x < (double) (this.x + this.width) && ((double) num1 > (double) this.x && (double) num1 < (double) (this.x + this.width)) && ((double) y > (double) this.y && (double) y < (double) (this.y + this.height) && ((double) num2 > (double) this.y && (double) num2 < (double) (this.y + this.height)));
    }

    [LineNumberTable(new byte[] {122, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect move(float cx, float cy)
    {
      this.x += cx;
      this.y += cy;
      return this;
    }

    [LineNumberTable(new byte[] {161, 30, 127, 18})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setCenter(Vec2 position)
    {
      this.setPosition(position.x - this.width / 2f, position.y - this.height / 2f);
      return this;
    }

    [LineNumberTable(new byte[] {160, 171, 119, 119, 112, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect grow(float amountX, float amountY)
    {
      this.x -= amountX / 2f;
      this.y -= amountY / 2f;
      this.width += amountX;
      this.height += amountY;
      return this;
    }

    [LineNumberTable(new byte[] {160, 204, 111, 119, 103, 138, 111, 119, 103, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect merge(float x, float y)
    {
      float num1 = Math.min(this.x, x);
      float num2 = Math.max(this.x + this.width, x);
      this.x = num1;
      this.width = num2 - num1;
      float num3 = Math.min(this.y, y);
      float num4 = Math.max(this.y + this.height, y);
      this.y = num3;
      this.height = num4 - num3;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getAspectRatio() => (double) this.height == 0.0 ? float.NaN : this.width / this.height;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getX() => this.x;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setX(float x)
    {
      this.x = x;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getY() => this.y;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setY(float y)
    {
      this.y = y;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getWidth() => this.width;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setWidth(float width)
    {
      this.width = width;
      return this;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getHeight() => this.height;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setHeight(float height)
    {
      this.height = height;
      return this;
    }

    [LineNumberTable(143)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 getPosition(Vec2 position) => position.set(this.x, this.y);

    [LineNumberTable(new byte[] {102, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect setPosition(Vec2 position)
    {
      this.x = position.x;
      this.y = position.y;
      return this;
    }

    [LineNumberTable(207)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 getSize(Vec2 size) => size.set(this.width, this.height);

    [LineNumberTable(232)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool contains(Circle circle) => (double) (circle.x - circle.radius) >= (double) this.x && (double) (circle.x + circle.radius) <= (double) (this.x + this.width) && ((double) (circle.y - circle.radius) >= (double) this.y && (double) (circle.y + circle.radius) <= (double) (this.y + this.height));

    [LineNumberTable(new byte[] {160, 158, 108, 108, 108, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect set(Rect rect)
    {
      this.x = rect.x;
      this.y = rect.y;
      this.width = rect.width;
      this.height = rect.height;
      return this;
    }

    [LineNumberTable(337)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect merge(Vec2 vec) => this.merge(vec.x, vec.y);

    [LineNumberTable(new byte[] {160, 232, 103, 111, 103, 111, 105, 102, 111, 111, 111, 239, 59, 232, 71, 103, 106, 103, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect merge(Vec2[] vecs)
    {
      float num1 = this.x;
      float num2 = this.x + this.width;
      float num3 = this.y;
      float num4 = this.y + this.height;
      for (int index = 0; index < vecs.Length; ++index)
      {
        Vec2 vec = vecs[index];
        num1 = Math.min(num1, vec.x);
        num2 = Math.max(num2, vec.x);
        num3 = Math.min(num3, vec.y);
        num4 = Math.max(num4, vec.y);
      }
      this.x = num1;
      this.width = num2 - num1;
      this.y = num3;
      this.height = num4 - num3;
      return this;
    }

    [LineNumberTable(new byte[] {161, 42, 136, 138, 184, 182, 127, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect fitOutside(Rect rect)
    {
      float aspectRatio = this.getAspectRatio();
      if ((double) aspectRatio > (double) rect.getAspectRatio())
        this.setSize(rect.height * aspectRatio, rect.height);
      else
        this.setSize(rect.width, rect.width / aspectRatio);
      this.setPosition(rect.x + rect.width / 2f - this.width / 2f, rect.y + rect.height / 2f - this.height / 2f);
      return this;
    }

    [LineNumberTable(new byte[] {161, 64, 136, 138, 184, 182, 127, 48})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect fitInside(Rect rect)
    {
      float aspectRatio = this.getAspectRatio();
      if ((double) aspectRatio < (double) rect.getAspectRatio())
        this.setSize(rect.height * aspectRatio, rect.height);
      else
        this.setSize(rect.width, rect.width / aspectRatio);
      this.setPosition(rect.x + rect.width / 2f - this.width / 2f, rect.y + rect.height / 2f - this.height / 2f);
      return this;
    }

    [LineNumberTable(453)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append("[").append(this.x).append(",").append(this.y).append(",").append(this.width).append(",").append(this.height).append("]").toString();

    [LineNumberTable(new byte[] {161, 93, 106, 108, 108, 159, 25, 111, 114, 114, 121, 127, 0, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Rect fromString(string v)
    {
      int num1 = String.instancehelper_indexOf(v, 44, 1);
      int num2 = String.instancehelper_indexOf(v, 44, num1 + 1);
      int num3 = String.instancehelper_indexOf(v, 44, num2 + 1);
      if (num1 != -1 && num2 != -1 && (num3 != -1 && String.instancehelper_charAt(v, 0) == '['))
      {
        if (String.instancehelper_charAt(v, String.instancehelper_length(v) - 1) == ']')
        {
          Rect rect;
          try
          {
            rect = this.set(Float.parseFloat(String.instancehelper_substring(v, 1, num1)), Float.parseFloat(String.instancehelper_substring(v, num1 + 1, num2)), Float.parseFloat(String.instancehelper_substring(v, num2 + 1, num3)), Float.parseFloat(String.instancehelper_substring(v, num3 + 1, String.instancehelper_length(v) - 1)));
          }
          catch (NumberFormatException ex)
          {
            goto label_5;
          }
          return rect;
label_5:;
        }
      }
      string message = new StringBuilder().append("Malformed Rectangle: ").append(v).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new ArcRuntimeException(message);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float perimeter() => 2f * (this.width + this.height);

    [LineNumberTable(new byte[] {161, 119, 99, 98, 115, 115, 115, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int hashCode()
    {
      FloatConverter floatConverter;
      return 31 * (31 * (31 * (31 * 1 + FloatConverter.ToInt(this.height, ref floatConverter)) + FloatConverter.ToInt(this.width, ref floatConverter)) + FloatConverter.ToInt(this.x, ref floatConverter)) + FloatConverter.ToInt(this.y, ref floatConverter);
    }

    [LineNumberTable(new byte[] {159, 140, 173, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    static Rect()
    {
      if (ByteCodeHelper.isAlreadyInited("arc.math.geom.Rect"))
        return;
      Rect.__\u003C\u003Etmp = new Rect();
      Rect.__\u003C\u003Etmp2 = new Rect();
    }

    [Modifiers]
    public static Rect tmp
    {
      [HideFromJava] get => Rect.__\u003C\u003Etmp;
    }

    [Modifiers]
    public static Rect tmp2
    {
      [HideFromJava] get => Rect.__\u003C\u003Etmp2;
    }
  }
}
