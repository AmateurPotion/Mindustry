// Decompiled with JetBrains decompiler
// Type: mindustry.graphics.Drawf
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.math;
using arc.math.geom;
using arc.util;
using IKVM.Attributes;
using java.lang;
using mindustry.ctype;
using mindustry.game;
using mindustry.gen;
using mindustry.ui;
using mindustry.world;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.graphics
{
  public class Drawf : Object
  {
    [LineNumberTable(new byte[] {159, 188, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(float x, float y, float radius, Color color, float opacity) => Vars.renderer.__\u003C\u003Elights.add(x, y, radius, color, opacity);

    [LineNumberTable(new byte[] {124, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float radius, Color color) => Drawf.square(x, y, radius, 45f, color);

    [LineNumberTable(new byte[] {84, 111, 107, 107, 107, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void dashCircle(float x, float y, float rad, Color color)
    {
      Lines.stroke(3f, Pal.gray);
      Lines.dashCircle(x, y, rad);
      Lines.stroke(1f, color);
      Lines.dashCircle(x, y, rad);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {24, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void selected(Building tile, Color color) => Drawf.selected(tile.tile(), color);

    [LineNumberTable(new byte[] {32, 102, 105, 104, 127, 0, 255, 32, 61, 233, 71, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void selected(int x, int y, Block block, Color color)
    {
      Draw.color(color);
      for (int index = 0; index < 4; ++index)
      {
        Point2 point2 = Geometry.__\u003C\u003Ed8edge[index];
        float num = (float) -Math.max(block.size - 1, 0) / 2f * 8f;
        Draw.rect("block-select", (float) (x * 8) + block.offset + num * (float) point2.x, (float) (y * 8) + block.offset + num * (float) point2.y, (float) (index * 90));
      }
      Draw.reset();
    }

    [LineNumberTable(new byte[] {92, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circles(float x, float y, float rad) => Drawf.circles(x, y, rad, Pal.accent);

    [LineNumberTable(new byte[] {160, 85, 127, 12})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void laser(
      Team team,
      TextureRegion line,
      TextureRegion edge,
      float x,
      float y,
      float x2,
      float y2,
      float scale)
    {
      Drawf.laser(team, line, edge, x, y, x2, y2, Mathf.angle(x2 - x, y2 - y), scale);
    }

    [LineNumberTable(new byte[] {4, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(Team team, Position pos, float radius, Color color, float opacity) => Drawf.light(team, pos.getX(), pos.getY(), radius, color, opacity);

    [LineNumberTable(new byte[] {160, 107, 106, 127, 31})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void tri(float x, float y, float width, float length, float rotation)
    {
      float originY = 0.2698413f * length;
      Draw.rect((TextureRegion) Core.atlas.find("shape-3"), x, y - originY + length / 2f, width, length, width / 2f, originY, rotation - 90f);
    }

    [LineNumberTable(new byte[] {16, 127, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(
      Team team,
      float x,
      float y,
      float x2,
      float y2,
      float stroke,
      Color tint,
      float alpha)
    {
      if (!Drawf.allowLight(team))
        return;
      Vars.renderer.__\u003C\u003Elights.line(x, y, x2, y2, stroke, tint, alpha);
    }

    [LineNumberTable(new byte[] {0, 127, 3})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(
      Team team,
      float x,
      float y,
      float radius,
      Color color,
      float opacity)
    {
      if (!Drawf.allowLight(team))
        return;
      Vars.renderer.__\u003C\u003Elights.add(x, y, radius, color, opacity);
    }

    [LineNumberTable(new byte[] {44, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shadow(float x, float y, float rad) => Drawf.shadow(x, y, rad, 1f);

    [LineNumberTable(new byte[] {160, 116, 122})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void construct(
      float x,
      float y,
      TextureRegion region,
      float rotation,
      float progress,
      float speed,
      float time)
    {
      Drawf.construct(x, y, region, Pal.accent, rotation, progress, speed, time);
    }

    [LineNumberTable(new byte[] {159, 179, 103, 113, 170})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static float text()
    {
      float num = Draw.z();
      if (Vars.renderer.__\u003C\u003Epixelator.enabled())
        Draw.z(210f);
      return num;
    }

    [LineNumberTable(new byte[] {159, 167, 106, 108, 120, 127, 9, 106, 105, 120, 127, 9, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void target(float x, float y, float rad, float alpha, Color color)
    {
      Lines.stroke(3f);
      Draw.color(Pal.gray, alpha);
      Lines.poly(x, y, 4, rad, Time.time * 1.5f);
      Lines.spikes(x, y, 0.4285714f * rad, 0.8571429f * rad, 4, Time.time * 1.5f);
      Lines.stroke(1f);
      Draw.color(color, alpha);
      Lines.poly(x, y, 4, rad, Time.time * 1.5f);
      Lines.spikes(x, y, 0.4285714f * rad, 0.8571429f * rad, 4, Time.time * 1.5f);
      Draw.reset();
    }

    [LineNumberTable(70)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool allowLight([In] Team obj0) => Vars.renderer != null && (object.ReferenceEquals((object) obj0, (object) Team.__\u003C\u003Ederelict) || object.ReferenceEquals((object) obj0, (object) Vars.player.team()) || Vars.state.rules.enemyLights);

    [LineNumberTable(new byte[] {28, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void selected(Tile tile, Color color) => Drawf.selected((int) tile.x, (int) tile.y, tile.block(), color);

    [LineNumberTable(new byte[] {48, 125, 114, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shadow(float x, float y, float rad, float alpha)
    {
      Draw.color(0.0f, 0.0f, 0.0f, 0.4f * alpha);
      Draw.rect("circle-shadow", x, y, rad, rad);
      Draw.color();
    }

    [LineNumberTable(new byte[] {96, 111, 107, 107, 107, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void circles(float x, float y, float rad, Color color)
    {
      Lines.stroke(3f, Pal.gray);
      Lines.circle(x, y, rad);
      Lines.stroke(1f, color);
      Lines.circle(x, y, rad);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {112, 111, 116, 108, 116, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float radius, float rotation, Color color)
    {
      Lines.stroke(3f, Pal.gray);
      Lines.square(x, y, radius + 1f, rotation);
      Lines.stroke(1f, color);
      Lines.square(x, y, radius + 1f, rotation);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {120, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float radius, float rotation) => Drawf.square(x, y, radius, rotation, Pal.accent);

    [LineNumberTable(new byte[] {160, 72, 111, 102, 127, 1, 158, 106, 111, 103, 108, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void arrow(
      float x,
      float y,
      float x2,
      float y2,
      float length,
      float radius,
      Color color)
    {
      float rotation = Angles.angle(x, y, x2, y2);
      float num = 2f;
      Tmp.__\u003C\u003Ev1.set(x2, y2).sub(x, y).limit(length);
      float x1 = Tmp.__\u003C\u003Ev1.x + x;
      float y1 = Tmp.__\u003C\u003Ev1.y + y;
      Draw.color(Pal.gray);
      Fill.poly(x1, y1, 3, radius + num, rotation);
      Draw.color(color);
      Fill.poly(x1, y1, 3, radius, rotation);
      Draw.color();
    }

    [LineNumberTable(new byte[] {160, 93, 114, 154, 127, 28, 159, 22, 111, 126, 138, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void laser(
      Team team,
      TextureRegion line,
      TextureRegion edge,
      float x,
      float y,
      float x2,
      float y2,
      float rotation,
      float scale)
    {
      float num1 = 8f * scale * Draw.scl;
      float num2 = Mathf.cosDeg(rotation) * num1;
      float num3 = Mathf.sinDeg(rotation) * num1;
      Draw.rect(edge, x, y, (float) edge.width * scale * Draw.scl, (float) edge.height * scale * Draw.scl, rotation + 180f);
      Draw.rect(edge, x2, y2, (float) edge.width * scale * Draw.scl, (float) edge.height * scale * Draw.scl, rotation);
      Lines.stroke(12f * scale);
      Lines.line(line, x + num2, y + num3, x2 - num2, y2 - num3, false);
      Lines.stroke(1f);
      Drawf.light(team, x, y, x2, y2);
    }

    [LineNumberTable(new byte[] {12, 127, 16})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(Team team, float x, float y, float x2, float y2)
    {
      if (!Drawf.allowLight(team))
        return;
      Vars.renderer.__\u003C\u003Elights.line(x, y, x2, y2, 30f, Color.__\u003C\u003Eorange, 0.3f);
    }

    [LineNumberTable(new byte[] {160, 134, 118})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void construct(
      Building t,
      TextureRegion region,
      float rotation,
      float progress,
      float speed,
      float time)
    {
      Drawf.construct(t, region, Pal.accent, rotation, progress, speed, time);
    }

    [LineNumberTable(new byte[] {160, 120, 107, 109, 113, 114, 149, 106, 109, 133, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void construct(
      float x,
      float y,
      TextureRegion region,
      Color color,
      float rotation,
      float progress,
      float speed,
      float time)
    {
      Shaders.build.region = region;
      Shaders.build.progress = progress;
      Shaders.build.color.set(color);
      Shaders.build.color.a = speed;
      Shaders.build.time = (float) (-(double) time / 20.0);
      Draw.shader((Shader) Shaders.build);
      Draw.rect(region, x, y, rotation);
      Draw.shader();
      Draw.reset();
    }

    [LineNumberTable(new byte[] {160, 138, 107, 109, 113, 114, 149, 106, 116, 133, 106, 136, 159, 54, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void construct(
      Building t,
      TextureRegion region,
      Color color,
      float rotation,
      float progress,
      float speed,
      float time)
    {
      Shaders.build.region = region;
      Shaders.build.progress = progress;
      Shaders.build.color.set(color);
      Shaders.build.color.a = speed;
      Shaders.build.time = (float) (-(double) time / 20.0);
      Draw.shader((Shader) Shaders.build);
      Draw.rect(region, t.x, t.y, rotation);
      Draw.shader();
      Draw.color(Pal.accent);
      Draw.alpha(speed);
      Lines.lineAngleCenter(t.x + Mathf.sin(time, 20f, 4f * (float) t.block.size - 2f), t.y, 90f, (float) (t.block.size * 8) - 4f);
      Draw.reset();
    }

    [LineNumberTable(18)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Drawf()
    {
    }

    [LineNumberTable(new byte[] {159, 163, 113})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void target(float x, float y, float rad, Color color) => Drawf.target(x, y, rad, 1f, color);

    [LineNumberTable(new byte[] {8, 127, 2})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void light(
      Team team,
      float x,
      float y,
      TextureRegion region,
      Color color,
      float opacity)
    {
      if (!Drawf.allowLight(team))
        return;
      Vars.renderer.__\u003C\u003Elights.add(x, y, region, color, opacity);
    }

    [LineNumberTable(new byte[] {54, 106, 108, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shadow(TextureRegion region, float x, float y, float rotation)
    {
      Draw.color(Pal.shadow);
      Draw.rect(region, x, y, rotation);
      Draw.color();
    }

    [LineNumberTable(new byte[] {60, 106, 106, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shadow(TextureRegion region, float x, float y)
    {
      Draw.color(Pal.shadow);
      Draw.rect(region, x, y);
      Draw.color();
    }

    [LineNumberTable(new byte[] {66, 106, 114, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void shadow(
      TextureRegion region,
      float x,
      float y,
      float width,
      float height,
      float rotation)
    {
      Draw.color(Pal.shadow);
      Draw.rect(region, x, y, width, height, rotation);
      Draw.color();
    }

    [LineNumberTable(new byte[] {72, 105, 109, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void liquid(
      TextureRegion region,
      float x,
      float y,
      float alpha,
      Color color,
      float rotation)
    {
      Draw.color(color, alpha);
      Draw.rect(region, x, y, rotation);
      Draw.color();
    }

    [LineNumberTable(new byte[] {78, 105, 106, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void liquid(TextureRegion region, float x, float y, float alpha, Color color)
    {
      Draw.color(color, alpha);
      Draw.rect(region, x, y);
      Draw.color();
    }

    [LineNumberTable(new byte[] {104, 111, 114, 107, 107, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void select(float x, float y, float radius, Color color)
    {
      Lines.stroke(3f, Pal.gray);
      Lines.square(x, y, radius + 1f);
      Lines.stroke(1f, color);
      Lines.square(x, y, radius);
      Draw.reset();
    }

    [LineNumberTable(new byte[] {160, 64, 112})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void square(float x, float y, float radius) => Drawf.square(x, y, radius, 45f);

    [LineNumberTable(new byte[] {160, 68, 120})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void arrow(float x, float y, float x2, float y2, float length, float radius) => Drawf.arrow(x, y, x2, y2, length, radius, Pal.accent);

    [LineNumberTable(new byte[] {160, 89, 127, 14})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void laser(
      Team team,
      TextureRegion line,
      TextureRegion edge,
      float x,
      float y,
      float x2,
      float y2)
    {
      Drawf.laser(team, line, edge, x, y, x2, y2, Mathf.angle(x2 - x, y2 - y), 1f);
    }

    [LineNumberTable(new byte[] {160, 112, 123})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void construct(
      Building t,
      UnlockableContent content,
      float rotation,
      float progress,
      float speed,
      float time)
    {
      Drawf.construct(t, content.icon(Cicon.__\u003C\u003Efull), rotation, progress, speed, time);
    }
  }
}
