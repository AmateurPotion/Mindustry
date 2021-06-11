// Decompiled with JetBrains decompiler
// Type: arc.backend.sdl.SdlConfig
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.graphics;
using arc.graphics.gl;
using IKVM.Attributes;
using java.lang;
using System.Runtime.CompilerServices;

namespace arc.backend.sdl
{
  public class SdlConfig : Object
  {
    public int r;
    public int g;
    public int b;
    public int a;
    public int depth;
    public int stencil;
    public int samples;
    public HdpiMode hdpiMode;
    public int width;
    public int height;
    public bool resizable;
    public bool decorated;
    public bool maximized;
    public bool gl30;
    public int gl30Major;
    public int gl30Minor;
    public string title;
    public Color initialBackgroundColor;
    public bool initialVisible;
    public bool vSyncEnabled;
    internal Files.FileType windowIconFileType;
    internal string[] windowIconPaths;

    [LineNumberTable(new byte[] {159, 149, 104, 124, 110, 103, 139, 107, 107, 103, 103, 103, 103, 142, 107, 107, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SdlConfig()
    {
      SdlConfig sdlConfig = this;
      this.r = 8;
      this.g = 8;
      this.b = 8;
      this.a = 8;
      this.depth = 0;
      this.stencil = 0;
      this.samples = 0;
      this.hdpiMode = HdpiMode.__\u003C\u003Elogical;
      this.width = 640;
      this.height = 480;
      this.resizable = true;
      this.decorated = true;
      this.maximized = false;
      this.gl30 = false;
      this.gl30Major = 3;
      this.gl30Minor = 0;
      this.title = "Arc Application";
      this.initialBackgroundColor = Color.__\u003C\u003Eblack;
      this.initialVisible = true;
      this.vSyncEnabled = true;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setWindowIcon(Files.FileType fileType, params string[] filePaths)
    {
      this.windowIconFileType = fileType;
      this.windowIconPaths = filePaths;
    }
  }
}
