// Decompiled with JetBrains decompiler
// Type: arc.graphics.g3d.VertexBatch3D
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.graphics.gl;
using arc.math.geom;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.g3d
{
  public class VertexBatch3D : Object
  {
    [Modifiers]
    private int maxVertices;
    [Modifiers]
    private Mesh mesh;
    [Modifiers]
    private int numTexCoords;
    [Modifiers]
    private int vertexSize;
    [Modifiers]
    private int normalOffset;
    [Modifiers]
    private int colorOffset;
    [Modifiers]
    private int texCoordOffset;
    [Modifiers]
    private Mat3D proj;
    [Modifiers]
    private float[] vertices;
    [Modifiers]
    private string[] shaderUniformNames;
    private int vertexIdx;
    private int numSetTexCoords;
    private int numVertices;
    private Shader shader;
    private bool ownsShader;

    [LineNumberTable(new byte[] {159, 134, 68, 118, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexBatch3D(int maxVertices, bool hasNormals, bool hasColors, int numTexCoords)
    {
      int num1 = hasNormals ? 1 : 0;
      int num2 = hasColors ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(maxVertices, num1 != 0, num2 != 0, numTexCoords, VertexBatch3D.createDefaultShader(num1 != 0, num2 != 0, numTexCoords));
      VertexBatch3D vertexBatch3D = this;
      this.ownsShader = true;
    }

    [LineNumberTable(new byte[] {160, 111, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void proj(Mat3D projModelView) => this.proj.set(projModelView);

    [LineNumberTable(new byte[] {160, 115, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flush(int primitiveType) => this.flush(primitiveType, this.shader);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat3D proj() => this.proj;

    [LineNumberTable(new byte[] {97, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void color(Color color) => this.vertices[this.vertexIdx + this.colorOffset] = color.toFloatBits();

    [LineNumberTable(new byte[] {160, 86, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void vertex(Vec3 v) => this.vertex(v.x, v.y, v.z);

    [LineNumberTable(new byte[] {127, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tri2(Vec3 v1, Vec3 v2, Vec3 v3, Color color)
    {
      this.tri(v1, v2, v3, color);
      this.tri(v1, v3, v2, color);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getNumVertices() => this.numVertices;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getMaxVertices() => this.maxVertices;

    [LineNumberTable(new byte[] {160, 68, 127, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tri(Vec3 v1, Vec3 v2, Vec3 v3, Color color) => this.tri(v1.x, v1.y, v1.z, v2.x, v2.y, v2.z, v3.x, v3.y, v3.z, color);

    [LineNumberTable(new byte[] {160, 142, 123, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      if (this.ownsShader && this.shader != null)
        this.shader.dispose();
      this.mesh.dispose();
    }

    [LineNumberTable(new byte[] {160, 81, 103, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void vertex(Vec3 v, Color color)
    {
      this.color(color);
      this.vertex(v.x, v.y, v.z);
    }

    [LineNumberTable(new byte[] {160, 101, 121, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void vertex(float[] floats)
    {
      ByteCodeHelper.arraycopy_primitive_4((Array) floats, 0, (Array) this.vertices, this.vertexIdx, this.vertexSize);
      this.vertexIdx += this.vertexSize;
      ++this.numVertices;
    }

    [LineNumberTable(new byte[] {159, 111, 68, 105, 105})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Shader createDefaultShader(
      bool hasNormals,
      bool hasColors,
      int numTexCoords)
    {
      int num1 = hasNormals ? 1 : 0;
      int num2 = hasColors ? 1 : 0;
      return new Shader(VertexBatch3D.createVertexShader(num1 != 0, num2 != 0, numTexCoords), VertexBatch3D.createFragmentShader(num1 != 0, num2 != 0, numTexCoords));
    }

    [LineNumberTable(new byte[] {159, 133, 68, 232, 44, 235, 85, 103, 104, 136, 107, 143, 122, 147, 131, 99, 104, 136, 167, 99, 104, 136, 167, 136, 109, 105, 63, 5, 168})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexBatch3D(
      int maxVertices,
      bool hasNormals,
      bool hasColors,
      int numTexCoords,
      Shader shader)
    {
      int num1 = hasNormals ? 1 : 0;
      int num2 = hasColors ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      VertexBatch3D vertexBatch3D = this;
      this.proj = new Mat3D();
      this.maxVertices = maxVertices;
      this.numTexCoords = numTexCoords;
      this.shader = shader;
      VertexAttribute[] vertexAttributeArray = this.buildVertexAttributes(num1 != 0, num2 != 0, numTexCoords);
      this.mesh = new Mesh(false, maxVertices, 0, vertexAttributeArray);
      this.vertices = new float[maxVertices * (this.mesh.__\u003C\u003EvertexSize / 4)];
      this.vertexSize = this.mesh.__\u003C\u003EvertexSize / 4;
      int num3 = 3;
      if (num1 != 0)
      {
        this.normalOffset = num3;
        num3 += 2;
      }
      else
        this.normalOffset = 0;
      if (num2 != 0)
      {
        this.colorOffset = num3;
        ++num3;
      }
      else
        this.colorOffset = 0;
      this.texCoordOffset = num3;
      this.shaderUniformNames = new string[numTexCoords];
      for (int index = 0; index < numTexCoords; ++index)
        this.shaderUniformNames[index] = new StringBuilder().append("u_sampler").append(index).toString();
    }

    [LineNumberTable(new byte[] {159, 110, 132, 102, 107, 110, 110, 102, 63, 12, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private VertexAttribute[] buildVertexAttributes([In] bool obj0, [In] bool obj1, [In] int obj2)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      Seq seq1 = new Seq();
      seq1.add((object) VertexAttribute.__\u003C\u003Eposition3);
      if (num1 != 0)
        seq1.add((object) VertexAttribute.__\u003C\u003Enormal);
      if (num2 != 0)
        seq1.add((object) VertexAttribute.__\u003C\u003Ecolor);
      for (int index = 0; index < obj2; ++index)
      {
        Seq seq2 = seq1;
        VertexAttribute.__\u003Cclinit\u003E();
        VertexAttribute vertexAttribute = new VertexAttribute(2, new StringBuilder().append("a_texCoord").append(index).toString());
        seq2.add((object) vertexAttribute);
      }
      return (VertexAttribute[]) seq1.toArray((Class) ClassLiteral<VertexAttribute>.Value);
    }

    [LineNumberTable(new byte[] {159, 124, 68, 111, 116, 159, 0, 102, 60, 198, 108, 150, 102, 60, 198, 159, 1, 102, 63, 23, 166, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string createVertexShader([In] bool obj0, [In] bool obj1, [In] int obj2)
    {
      int num1 = obj0 ? 1 : 0;
      int num2 = obj1 ? 1 : 0;
      StringBuilder stringBuilder = new StringBuilder(new StringBuilder().append("attribute vec4 a_position;\n").append(num1 == 0 ? "" : "attribute vec3 a_normal;\n").append(num2 == 0 ? "" : "attribute vec4 a_color;\n").toString());
      for (int index = 0; index < obj2; ++index)
        stringBuilder.append("attribute vec2 a_texCoord").append(index).append(";\n");
      stringBuilder.append("uniform mat4 u_proj;\n");
      stringBuilder.append(num2 == 0 ? "" : "varying vec4 v_col;\n");
      for (int index = 0; index < obj2; ++index)
        stringBuilder.append("varying vec2 v_tex").append(index).append(";\n");
      stringBuilder.append("void main() {\n   gl_Position = u_proj * a_position;\n").append(num2 == 0 ? "" : "   v_col = a_color;\n");
      for (int index = 0; index < obj2; ++index)
        stringBuilder.append("   v_tex").append(index).append(" = ").append("a_texCoord").append(index).append(";\n");
      stringBuilder.append("   gl_PointSize = 1.0;\n");
      stringBuilder.append("}\n");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {159, 118, 130, 134, 111, 102, 124, 28, 230, 69, 159, 1, 144, 105, 102, 159, 15, 255, 13, 60, 233, 72, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string createFragmentShader([In] bool obj0, [In] bool obj1, [In] int obj2)
    {
      int num = obj1 ? 1 : 0;
      StringBuilder stringBuilder = new StringBuilder();
      if (num != 0)
        stringBuilder.append("varying vec4 v_col;\n");
      for (int index = 0; index < obj2; ++index)
      {
        stringBuilder.append("varying vec2 v_tex").append(index).append(";\n");
        stringBuilder.append("uniform sampler2D u_sampler").append(index).append(";\n");
      }
      stringBuilder.append("void main(){\n   gl_FragColor = ").append(num == 0 ? "vec4(1, 1, 1, 1)" : "v_col");
      if (obj2 > 0)
        stringBuilder.append(" * ");
      for (int index = 0; index < obj2; ++index)
      {
        if (index == obj2 - 1)
          stringBuilder.append(" texture2D(u_sampler").append(index).append(",  v_tex").append(index).append(")");
        else
          stringBuilder.append(" texture2D(u_sampler").append(index).append(",  v_tex").append(index).append(") *");
      }
      stringBuilder.append(";\n}");
      return stringBuilder.toString();
    }

    [LineNumberTable(new byte[] {120, 110, 106, 108, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void normal(float x, float y, float z)
    {
      int index = this.vertexIdx + this.normalOffset;
      this.vertices[index] = x;
      this.vertices[index + 1] = y;
      this.vertices[index + 2] = z;
    }

    [LineNumberTable(new byte[] {160, 72, 104, 108, 104, 111, 104, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void tri(
      float x1,
      float y1,
      float z1,
      float x2,
      float y2,
      float z2,
      float x3,
      float y3,
      float z3,
      Color color)
    {
      this.color(color);
      this.vertex(x1, y1, z1);
      this.color(color);
      this.vertex(x2, y2, z2);
      this.color(color);
      this.vertex(x3, y3, z3);
    }

    [LineNumberTable(new byte[] {160, 90, 103, 106, 108, 140, 103, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void vertex(float x, float y, float z)
    {
      int vertexIdx = this.vertexIdx;
      this.vertices[vertexIdx] = x;
      this.vertices[vertexIdx + 1] = y;
      this.vertices[vertexIdx + 2] = z;
      this.numSetTexCoords = 0;
      this.vertexIdx += this.vertexSize;
      ++this.numVertices;
    }

    [LineNumberTable(new byte[] {160, 119, 105, 102, 102, 118, 107, 47, 134, 121, 141, 103, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void flush(int primitiveType, Shader shader)
    {
      if (this.numVertices == 0)
        return;
      shader.bind();
      shader.apply();
      shader.setUniformMatrix4("u_proj", this.proj.__\u003C\u003Eval);
      for (int index = 0; index < this.numTexCoords; ++index)
        shader.setUniformi(this.shaderUniformNames[index], index);
      this.mesh.setVertices(this.vertices, 0, this.vertexIdx);
      this.mesh.render(shader, primitiveType);
      this.numSetTexCoords = 0;
      this.vertexIdx = 0;
      this.numVertices = 0;
    }

    [LineNumberTable(new byte[] {159, 136, 164, 120, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public VertexBatch3D(bool hasNormals, bool hasColors, int numTexCoords)
    {
      int num1 = hasNormals ? 1 : 0;
      int num2 = hasColors ? 1 : 0;
      // ISSUE: explicit constructor call
      this.\u002Ector(5000, num1 != 0, num2 != 0, numTexCoords, VertexBatch3D.createDefaultShader(num1 != 0, num2 != 0, numTexCoords));
      VertexBatch3D vertexBatch3D = this;
      this.ownsShader = true;
    }

    [LineNumberTable(new byte[] {91, 115, 103, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setShader(Shader shader)
    {
      if (this.ownsShader)
        this.shader.dispose();
      this.shader = shader;
      this.ownsShader = false;
    }

    [LineNumberTable(new byte[] {101, 127, 4})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void color(float r, float g, float b, float a) => this.vertices[this.vertexIdx + this.colorOffset] = Color.toFloatBits(r, g, b, a);

    [LineNumberTable(new byte[] {105, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void color(float colorBits) => this.vertices[this.vertexIdx + this.colorOffset] = colorBits;

    [LineNumberTable(new byte[] {109, 110, 113, 115, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void texCoord(float u, float v)
    {
      int num = this.vertexIdx + this.texCoordOffset;
      this.vertices[num + this.numSetTexCoords] = u;
      this.vertices[num + this.numSetTexCoords + 1] = v;
      this.numSetTexCoords += 2;
    }

    [LineNumberTable(new byte[] {116, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void normal(Vec3 v) => this.normal(v.x, v.y, v.z);
  }
}
