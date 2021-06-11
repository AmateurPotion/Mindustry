// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.IndexedRenderer
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math;
using arc.util;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace mindustry.graphics
{
  public class IndexedRenderer : Object, Disposable
  {
    private const int vsize = 5;
    [Modifiers]
    private Shader program;
    private Mesh mesh;
    private float[] tmpVerts;
    private float[] vertices;
    private Mat projMatrix;
    private Mat transMatrix;
    private Mat combined;
    private float color;

    [LineNumberTable(new byte[] {160, 101, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.mesh.dispose();
      this.program.dispose();
    }

    [LineNumberTable(new byte[] {159, 186, 232, 32, 245, 88, 173, 107, 107, 107, 177, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public IndexedRenderer(int sprites)
    {
      IndexedRenderer indexedRenderer = this;
      this.program = new Shader("attribute vec4 a_position;\nattribute vec4 a_color;\nattribute vec2 a_texCoord0;\nuniform mat4 u_projTrans;\nvarying vec4 v_color;\nvarying vec2 v_texCoords;\nvoid main(){\n   v_color = a_color;\n   v_color.a = v_color.a * (255.0/254.0);\n   v_texCoords = a_texCoord0;\n   gl_Position = u_projTrans * a_position;\n}", "varying lowp vec4 v_color;\nvarying vec2 v_texCoords;\nuniform sampler2D u_texture;\nvoid main(){\n  gl_FragColor = v_color * texture2D(u_texture, v_texCoords);\n}");
      this.tmpVerts = new float[30];
      this.projMatrix = new Mat();
      this.transMatrix = new Mat();
      this.combined = new Mat();
      this.color = Color.__\u003C\u003Ewhite.toFloatBits();
      this.resize(sprites);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Mat getTransformMatrix() => this.transMatrix;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setProjectionMatrix(Mat matrix) => this.projMatrix = matrix;

    [LineNumberTable(new byte[] {159, 191, 138, 134, 107, 134, 118, 145, 124})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void render(Texture texture)
    {
      Gl.enable(3042);
      this.updateMatrix();
      this.program.bind();
      texture.bind();
      this.program.setUniformMatrix4("u_projTrans", this.combined);
      this.program.setUniformi("u_texture", 0);
      this.mesh.render(this.program, 4, 0, this.vertices.Length / 5);
    }

    [LineNumberTable(new byte[] {69, 103, 103, 103, 135, 152, 107, 139, 101, 101, 105, 137, 104, 137, 116, 116, 116, 116, 116, 116, 108, 140, 104, 136, 99, 109, 109, 109, 108, 140, 109, 109, 109, 108, 140, 109, 109, 109, 108, 172, 109, 109, 109, 108, 140, 109, 109, 109, 108, 140, 109, 109, 109, 108, 140, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(
      int index,
      TextureRegion region,
      float x,
      float y,
      float w,
      float h,
      float rotation)
    {
      float u = region.u;
      float v2 = region.v2;
      float u2 = region.u2;
      float v = region.v;
      float num1 = w / 2f;
      float num2 = h / 2f;
      float num3 = Mathf.cosDeg(rotation);
      float num4 = Mathf.sinDeg(rotation);
      float num5 = -num1;
      float num6 = -num2;
      float num7 = w - num1;
      float num8 = h - num2;
      float num9 = x + num1;
      float num10 = y + num2;
      float num11 = num3 * num5 - num4 * num6 + num9;
      float num12 = num4 * num5 + num3 * num6 + num10;
      float num13 = num3 * num5 - num4 * num8 + num9;
      float num14 = num4 * num5 + num3 * num8 + num10;
      float num15 = num3 * num7 - num4 * num8 + num9;
      float num16 = num4 * num7 + num3 * num8 + num10;
      float num17 = num11 + (num15 - num13);
      float num18 = num16 - (num14 - num12);
      float[] tmpVerts = this.tmpVerts;
      float color = this.color;
      int num19 = 0;
      float[] numArray1 = tmpVerts;
      int index1 = num19;
      int num20 = num19 + 1;
      double num21 = (double) num11;
      numArray1[index1] = (float) num21;
      float[] numArray2 = tmpVerts;
      int index2 = num20;
      int num22 = num20 + 1;
      double num23 = (double) num12;
      numArray2[index2] = (float) num23;
      float[] numArray3 = tmpVerts;
      int index3 = num22;
      int num24 = num22 + 1;
      double num25 = (double) color;
      numArray3[index3] = (float) num25;
      float[] numArray4 = tmpVerts;
      int index4 = num24;
      int num26 = num24 + 1;
      double num27 = (double) u;
      numArray4[index4] = (float) num27;
      float[] numArray5 = tmpVerts;
      int index5 = num26;
      int num28 = num26 + 1;
      double num29 = (double) v2;
      numArray5[index5] = (float) num29;
      float[] numArray6 = tmpVerts;
      int index6 = num28;
      int num30 = num28 + 1;
      double num31 = (double) num13;
      numArray6[index6] = (float) num31;
      float[] numArray7 = tmpVerts;
      int index7 = num30;
      int num32 = num30 + 1;
      double num33 = (double) num14;
      numArray7[index7] = (float) num33;
      float[] numArray8 = tmpVerts;
      int index8 = num32;
      int num34 = num32 + 1;
      double num35 = (double) color;
      numArray8[index8] = (float) num35;
      float[] numArray9 = tmpVerts;
      int index9 = num34;
      int num36 = num34 + 1;
      double num37 = (double) u;
      numArray9[index9] = (float) num37;
      float[] numArray10 = tmpVerts;
      int index10 = num36;
      int num38 = num36 + 1;
      double num39 = (double) v;
      numArray10[index10] = (float) num39;
      float[] numArray11 = tmpVerts;
      int index11 = num38;
      int num40 = num38 + 1;
      double num41 = (double) num15;
      numArray11[index11] = (float) num41;
      float[] numArray12 = tmpVerts;
      int index12 = num40;
      int num42 = num40 + 1;
      double num43 = (double) num16;
      numArray12[index12] = (float) num43;
      float[] numArray13 = tmpVerts;
      int index13 = num42;
      int num44 = num42 + 1;
      double num45 = (double) color;
      numArray13[index13] = (float) num45;
      float[] numArray14 = tmpVerts;
      int index14 = num44;
      int num46 = num44 + 1;
      double num47 = (double) u2;
      numArray14[index14] = (float) num47;
      float[] numArray15 = tmpVerts;
      int index15 = num46;
      int num48 = num46 + 1;
      double num49 = (double) v;
      numArray15[index15] = (float) num49;
      float[] numArray16 = tmpVerts;
      int index16 = num48;
      int num50 = num48 + 1;
      double num51 = (double) num15;
      numArray16[index16] = (float) num51;
      float[] numArray17 = tmpVerts;
      int index17 = num50;
      int num52 = num50 + 1;
      double num53 = (double) num16;
      numArray17[index17] = (float) num53;
      float[] numArray18 = tmpVerts;
      int index18 = num52;
      int num54 = num52 + 1;
      double num55 = (double) color;
      numArray18[index18] = (float) num55;
      float[] numArray19 = tmpVerts;
      int index19 = num54;
      int num56 = num54 + 1;
      double num57 = (double) u2;
      numArray19[index19] = (float) num57;
      float[] numArray20 = tmpVerts;
      int index20 = num56;
      int num58 = num56 + 1;
      double num59 = (double) v;
      numArray20[index20] = (float) num59;
      float[] numArray21 = tmpVerts;
      int index21 = num58;
      int num60 = num58 + 1;
      double num61 = (double) num17;
      numArray21[index21] = (float) num61;
      float[] numArray22 = tmpVerts;
      int index22 = num60;
      int num62 = num60 + 1;
      double num63 = (double) num18;
      numArray22[index22] = (float) num63;
      float[] numArray23 = tmpVerts;
      int index23 = num62;
      int num64 = num62 + 1;
      double num65 = (double) color;
      numArray23[index23] = (float) num65;
      float[] numArray24 = tmpVerts;
      int index24 = num64;
      int num66 = num64 + 1;
      double num67 = (double) u2;
      numArray24[index24] = (float) num67;
      float[] numArray25 = tmpVerts;
      int index25 = num66;
      int num68 = num66 + 1;
      double num69 = (double) v2;
      numArray25[index25] = (float) num69;
      float[] numArray26 = tmpVerts;
      int index26 = num68;
      int num70 = num68 + 1;
      double num71 = (double) num11;
      numArray26[index26] = (float) num71;
      float[] numArray27 = tmpVerts;
      int index27 = num70;
      int num72 = num70 + 1;
      double num73 = (double) num12;
      numArray27[index27] = (float) num73;
      float[] numArray28 = tmpVerts;
      int index28 = num72;
      int num74 = num72 + 1;
      double num75 = (double) color;
      numArray28[index28] = (float) num75;
      float[] numArray29 = tmpVerts;
      int index29 = num74;
      int num76 = num74 + 1;
      double num77 = (double) u;
      numArray29[index29] = (float) num77;
      float[] numArray30 = tmpVerts;
      int index30 = num76;
      int num78 = num76 + 1;
      double num79 = (double) v2;
      numArray30[index30] = (float) num79;
      this.mesh.updateVertices(index * 5 * 6, tmpVerts);
    }

    [LineNumberTable(new byte[] {17, 104, 105, 103, 103, 104, 136, 104, 136, 99, 109, 110, 109, 108, 140, 109, 108, 109, 108, 141, 108, 108, 109, 109, 173, 108, 108, 109, 109, 141, 108, 110, 109, 109, 140, 109, 110, 109, 108, 140, 115})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void draw(
      int index,
      TextureRegion region,
      float x,
      float y,
      float w,
      float h)
    {
      float num1 = x + w;
      float num2 = y + h;
      float u = region.u;
      float v2 = region.v2;
      float u2 = region.u2;
      float v = region.v;
      float[] tmpVerts = this.tmpVerts;
      float color = this.color;
      int num3 = 0;
      float[] numArray1 = tmpVerts;
      int index1 = num3;
      int num4 = num3 + 1;
      double num5 = (double) x;
      numArray1[index1] = (float) num5;
      float[] numArray2 = tmpVerts;
      int index2 = num4;
      int num6 = num4 + 1;
      double num7 = (double) y;
      numArray2[index2] = (float) num7;
      float[] numArray3 = tmpVerts;
      int index3 = num6;
      int num8 = num6 + 1;
      double num9 = (double) color;
      numArray3[index3] = (float) num9;
      float[] numArray4 = tmpVerts;
      int index4 = num8;
      int num10 = num8 + 1;
      double num11 = (double) u;
      numArray4[index4] = (float) num11;
      float[] numArray5 = tmpVerts;
      int index5 = num10;
      int num12 = num10 + 1;
      double num13 = (double) v2;
      numArray5[index5] = (float) num13;
      float[] numArray6 = tmpVerts;
      int index6 = num12;
      int num14 = num12 + 1;
      double num15 = (double) x;
      numArray6[index6] = (float) num15;
      float[] numArray7 = tmpVerts;
      int index7 = num14;
      int num16 = num14 + 1;
      double num17 = (double) num2;
      numArray7[index7] = (float) num17;
      float[] numArray8 = tmpVerts;
      int index8 = num16;
      int num18 = num16 + 1;
      double num19 = (double) color;
      numArray8[index8] = (float) num19;
      float[] numArray9 = tmpVerts;
      int index9 = num18;
      int num20 = num18 + 1;
      double num21 = (double) u;
      numArray9[index9] = (float) num21;
      float[] numArray10 = tmpVerts;
      int index10 = num20;
      int num22 = num20 + 1;
      double num23 = (double) v;
      numArray10[index10] = (float) num23;
      float[] numArray11 = tmpVerts;
      int index11 = num22;
      int num24 = num22 + 1;
      double num25 = (double) num1;
      numArray11[index11] = (float) num25;
      float[] numArray12 = tmpVerts;
      int index12 = num24;
      int num26 = num24 + 1;
      double num27 = (double) num2;
      numArray12[index12] = (float) num27;
      float[] numArray13 = tmpVerts;
      int index13 = num26;
      int num28 = num26 + 1;
      double num29 = (double) color;
      numArray13[index13] = (float) num29;
      float[] numArray14 = tmpVerts;
      int index14 = num28;
      int num30 = num28 + 1;
      double num31 = (double) u2;
      numArray14[index14] = (float) num31;
      float[] numArray15 = tmpVerts;
      int index15 = num30;
      int num32 = num30 + 1;
      double num33 = (double) v;
      numArray15[index15] = (float) num33;
      float[] numArray16 = tmpVerts;
      int index16 = num32;
      int num34 = num32 + 1;
      double num35 = (double) num1;
      numArray16[index16] = (float) num35;
      float[] numArray17 = tmpVerts;
      int index17 = num34;
      int num36 = num34 + 1;
      double num37 = (double) num2;
      numArray17[index17] = (float) num37;
      float[] numArray18 = tmpVerts;
      int index18 = num36;
      int num38 = num36 + 1;
      double num39 = (double) color;
      numArray18[index18] = (float) num39;
      float[] numArray19 = tmpVerts;
      int index19 = num38;
      int num40 = num38 + 1;
      double num41 = (double) u2;
      numArray19[index19] = (float) num41;
      float[] numArray20 = tmpVerts;
      int index20 = num40;
      int num42 = num40 + 1;
      double num43 = (double) v;
      numArray20[index20] = (float) num43;
      float[] numArray21 = tmpVerts;
      int index21 = num42;
      int num44 = num42 + 1;
      double num45 = (double) num1;
      numArray21[index21] = (float) num45;
      float[] numArray22 = tmpVerts;
      int index22 = num44;
      int num46 = num44 + 1;
      double num47 = (double) y;
      numArray22[index22] = (float) num47;
      float[] numArray23 = tmpVerts;
      int index23 = num46;
      int num48 = num46 + 1;
      double num49 = (double) color;
      numArray23[index23] = (float) num49;
      float[] numArray24 = tmpVerts;
      int index24 = num48;
      int num50 = num48 + 1;
      double num51 = (double) u2;
      numArray24[index24] = (float) num51;
      float[] numArray25 = tmpVerts;
      int index25 = num50;
      int num52 = num50 + 1;
      double num53 = (double) v2;
      numArray25[index25] = (float) num53;
      float[] numArray26 = tmpVerts;
      int index26 = num52;
      int num54 = num52 + 1;
      double num55 = (double) x;
      numArray26[index26] = (float) num55;
      float[] numArray27 = tmpVerts;
      int index27 = num54;
      int num56 = num54 + 1;
      double num57 = (double) y;
      numArray27[index27] = (float) num57;
      float[] numArray28 = tmpVerts;
      int index28 = num56;
      int num58 = num56 + 1;
      double num59 = (double) color;
      numArray28[index28] = (float) num59;
      float[] numArray29 = tmpVerts;
      int index29 = num58;
      int num60 = num58 + 1;
      double num61 = (double) u;
      numArray29[index29] = (float) num61;
      float[] numArray30 = tmpVerts;
      int index30 = num60;
      int num62 = num60 + 1;
      double num63 = (double) v2;
      numArray30[index30] = (float) num63;
      this.mesh.updateVertices(index * 5 * 6, tmpVerts);
    }

    [LineNumberTable(new byte[] {13, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setColor(Color color) => this.color = color.toFloatBits();

    [LineNumberTable(new byte[] {160, 85, 147, 223, 15, 112, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void resize(int sprites)
    {
      if (this.mesh != null)
        this.mesh.dispose();
      this.mesh = new Mesh(true, 6 * sprites, 0, new VertexAttribute[3]
      {
        VertexAttribute.__\u003C\u003Eposition,
        VertexAttribute.__\u003C\u003Ecolor,
        VertexAttribute.__\u003C\u003EtexCoords
      });
      this.vertices = new float[6 * sprites * 5];
      this.mesh.setVertices(this.vertices);
    }

    [LineNumberTable(new byte[] {160, 96, 125})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void updateMatrix() => this.combined.set(this.projMatrix).mul(this.transMatrix);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);
  }
}
