// Decompiled with JetBrains decompiler
// Type: arc.graphics.gl.GLVersion
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util.regex;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.graphics.gl
{
  public class GLVersion : Object
  {
    internal string __\u003C\u003EvendorString;
    internal string __\u003C\u003ErendererString;
    internal GLVersion.GlType __\u003C\u003Etype;
    public int majorVersion;
    public int minorVersion;
    public int releaseVersion;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool atLeast(int testMajorVersion, int testMinorVersion) => this.majorVersion > testMajorVersion || this.majorVersion == testMajorVersion && this.minorVersion >= testMinorVersion;

    [LineNumberTable(new byte[] {159, 159, 104, 122, 122, 122, 122, 139, 146, 110, 146, 110, 146, 142, 103, 103, 103, 103, 167, 103, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public GLVersion(
      Application.ApplicationType appType,
      string versionString,
      string vendorString,
      string rendererString)
    {
      GLVersion glVersion = this;
      this.__\u003C\u003Etype = !object.ReferenceEquals((object) appType, (object) Application.ApplicationType.__\u003C\u003Eandroid) ? (!object.ReferenceEquals((object) appType, (object) Application.ApplicationType.__\u003C\u003EiOS) ? (!object.ReferenceEquals((object) appType, (object) Application.ApplicationType.__\u003C\u003Edesktop) ? (!object.ReferenceEquals((object) appType, (object) Application.ApplicationType.__\u003C\u003Eweb) ? GLVersion.GlType.__\u003C\u003ENONE : GLVersion.GlType.__\u003C\u003EWebGL) : GLVersion.GlType.__\u003C\u003EOpenGL) : GLVersion.GlType.__\u003C\u003EGLES) : GLVersion.GlType.__\u003C\u003EGLES;
      if (object.ReferenceEquals((object) this.__\u003C\u003Etype, (object) GLVersion.GlType.__\u003C\u003EGLES))
        this.extractVersion("OpenGL ES (\\d(\\.\\d){0,2})", versionString);
      else if (object.ReferenceEquals((object) this.__\u003C\u003Etype, (object) GLVersion.GlType.__\u003C\u003EWebGL))
        this.extractVersion("WebGL (\\d(\\.\\d){0,2})", versionString);
      else if (object.ReferenceEquals((object) this.__\u003C\u003Etype, (object) GLVersion.GlType.__\u003C\u003EOpenGL))
      {
        this.extractVersion("(\\d(\\.\\d){0,2})", versionString);
      }
      else
      {
        this.majorVersion = -1;
        this.minorVersion = -1;
        this.releaseVersion = -1;
        vendorString = "";
        rendererString = "";
      }
      this.__\u003C\u003EvendorString = vendorString;
      this.__\u003C\u003ErendererString = rendererString;
    }

    [LineNumberTable(new byte[] {159, 188, 103, 120, 104, 103, 105, 110, 113, 122, 122, 98, 127, 6, 103, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void extractVersion([In] string obj0, [In] string obj1)
    {
      Pattern pattern = Pattern.compile(obj0);
      object obj = (object) obj1;
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj;
      CharSequence charSequence2 = charSequence1;
      Matcher matcher = pattern.matcher(charSequence2);
      if (matcher.find())
      {
        string[] strArray = String.instancehelper_split(matcher.group(1), "\\.");
        this.majorVersion = this.parseInt(strArray[0], 2);
        this.minorVersion = strArray.Length >= 2 ? this.parseInt(strArray[1], 0) : 0;
        this.releaseVersion = strArray.Length >= 3 ? this.parseInt(strArray[2], 0) : 0;
      }
      else
      {
        Log.err(new StringBuilder().append("[Arc GL] Invalid version string: ").append(obj1).toString());
        this.majorVersion = 2;
        this.minorVersion = 0;
        this.releaseVersion = 0;
      }
    }

    [LineNumberTable(new byte[] {16, 117, 97, 127, 22})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private int parseInt([In] string obj0, [In] int obj1)
    {
      int num;
      try
      {
        num = Integer.parseInt(obj0);
      }
      catch (NumberFormatException ex)
      {
        goto label_3;
      }
      return num;
label_3:
      Log.err(new StringBuilder().append("[Arc GL] Error parsing number: ").append(obj0).append(", assuming: ").append(obj1).toString());
      return obj1;
    }

    [LineNumberTable(85)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getDebugVersionString() => new StringBuilder().append("Type: ").append((object) this.__\u003C\u003Etype).append("\nVersion: ").append(this.majorVersion).append(":").append(this.minorVersion).append(":").append(this.releaseVersion).append("\nVendor: ").append(this.__\u003C\u003EvendorString).append("\nRenderer: ").append(this.__\u003C\u003ErendererString).toString();

    [LineNumberTable(93)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string toString() => new StringBuilder().append((object) this.__\u003C\u003Etype).append(" ").append(this.majorVersion).append(".").append(this.minorVersion).append(".").append(this.releaseVersion).append(" / ").append(this.__\u003C\u003EvendorString).append(" / ").append(this.__\u003C\u003ErendererString).toString();

    [Modifiers]
    public string vendorString
    {
      [HideFromJava] get => this.__\u003C\u003EvendorString;
      [HideFromJava] [param: In] private set => this.__\u003C\u003EvendorString = value;
    }

    [Modifiers]
    public string rendererString
    {
      [HideFromJava] get => this.__\u003C\u003ErendererString;
      [HideFromJava] [param: In] private set => this.__\u003C\u003ErendererString = value;
    }

    [Modifiers]
    public GLVersion.GlType type
    {
      [HideFromJava] get => this.__\u003C\u003Etype;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Etype = value;
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/graphics/gl/GLVersion$GlType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class GlType : Enum
    {
      [Modifiers]
      internal static GLVersion.GlType __\u003C\u003EOpenGL;
      [Modifiers]
      internal static GLVersion.GlType __\u003C\u003EGLES;
      [Modifiers]
      internal static GLVersion.GlType __\u003C\u003EWebGL;
      [Modifiers]
      internal static GLVersion.GlType __\u003C\u003ENONE;
      [Modifiers]
      private static GLVersion.GlType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(96)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private GlType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(96)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GLVersion.GlType[] values() => (GLVersion.GlType[]) GLVersion.GlType.\u0024VALUES.Clone();

      [LineNumberTable(96)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static GLVersion.GlType valueOf(string name) => (GLVersion.GlType) Enum.valueOf((Class) ClassLiteral<GLVersion.GlType>.Value, name);

      [LineNumberTable(new byte[] {159, 118, 109, 112, 112, 112, 240, 60})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static GlType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.graphics.gl.GLVersion$GlType"))
          return;
        GLVersion.GlType.__\u003C\u003EOpenGL = new GLVersion.GlType(nameof (OpenGL), 0);
        GLVersion.GlType.__\u003C\u003EGLES = new GLVersion.GlType(nameof (GLES), 1);
        GLVersion.GlType.__\u003C\u003EWebGL = new GLVersion.GlType(nameof (WebGL), 2);
        GLVersion.GlType.__\u003C\u003ENONE = new GLVersion.GlType(nameof (NONE), 3);
        GLVersion.GlType.\u0024VALUES = new GLVersion.GlType[4]
        {
          GLVersion.GlType.__\u003C\u003EOpenGL,
          GLVersion.GlType.__\u003C\u003EGLES,
          GLVersion.GlType.__\u003C\u003EWebGL,
          GLVersion.GlType.__\u003C\u003ENONE
        };
      }

      [Modifiers]
      public static GLVersion.GlType OpenGL
      {
        [HideFromJava] get => GLVersion.GlType.__\u003C\u003EOpenGL;
      }

      [Modifiers]
      public static GLVersion.GlType GLES
      {
        [HideFromJava] get => GLVersion.GlType.__\u003C\u003EGLES;
      }

      [Modifiers]
      public static GLVersion.GlType WebGL
      {
        [HideFromJava] get => GLVersion.GlType.__\u003C\u003EWebGL;
      }

      [Modifiers]
      public static GLVersion.GlType NONE
      {
        [HideFromJava] get => GLVersion.GlType.__\u003C\u003ENONE;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        OpenGL,
        GLES,
        WebGL,
        NONE,
      }
    }
  }
}
