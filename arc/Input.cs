// Decompiled with JetBrains decompiler
// Type: arc.Input
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using arc.input;
using arc.math.geom;
using arc.util;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public abstract class Input : Object
  {
    protected internal const float deadzone = 0.3f;
    protected internal KeyboardDevice keyboard;
    [Signature("Larc/struct/Seq<Larc/input/InputDevice;>;")]
    protected internal Seq devices;
    protected internal InputMultiplexer inputMultiplexer;
    protected internal IntSet caughtKeys;
    protected internal Vec2 mouseReturn;

    public abstract int mouseX();

    public abstract int mouseY();

    [LineNumberTable(new byte[] {159, 68, 130, 99, 148, 146})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCatch(KeyCode code, bool c)
    {
      if (c)
        this.caughtKeys.add(code.ordinal());
      else
        this.caughtKeys.remove(code.ordinal());
    }

    [Signature("()Larc/struct/Seq<Larc/input/InputProcessor;>;")]
    [LineNumberTable(326)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getInputProcessors() => (Seq) this.inputMultiplexer.getProcessors();

    [LineNumberTable(199)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyTap(KeyBinds.KeyBind key) => Core.keybinds.get(key).key != null && this.keyboard.isTapped(Core.keybinds.get(key).key);

    [LineNumberTable(179)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyTap(KeyCode key) => this.keyboard.isTapped(key);

    [LineNumberTable(new byte[] {160, 202, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void addProcessor(InputProcessor processor) => this.inputMultiplexer.addProcessor(processor);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getTextInput(Input.TextInput input)
    {
    }

    [LineNumberTable(164)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool ctrl()
    {
      if (OS.isMac)
        return this.keyDown(KeyCode.__\u003C\u003Esym);
      return this.keyDown(KeyCode.__\u003C\u003EcontrolLeft) || this.keyDown(KeyCode.__\u003C\u003EcontrolRight);
    }

    [LineNumberTable(69)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mouse() => this.mouseReturn.set((float) this.mouseX(), (float) this.mouseY());

    [LineNumberTable(174)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyDown(KeyCode key) => this.keyboard.isPressed(key);

    [LineNumberTable(new byte[] {160, 95, 108, 104, 147, 127, 14, 63, 26})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float axis(KeyBinds.KeyBind key)
    {
      KeyBinds.Axis axis = Core.keybinds.get(key);
      if (axis.key != null)
        return this.keyboard.getAxis(axis.key);
      if (this.keyboard.isPressed(axis.min) && this.keyboard.isPressed(axis.max))
        return 0.0f;
      if (this.keyboard.isPressed(axis.min))
        return -1f;
      return this.keyboard.isPressed(axis.max) ? 1f : 0.0f;
    }

    [LineNumberTable(184)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyRelease(KeyCode key) => this.keyboard.isReleased(key);

    [LineNumberTable(189)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float axis(KeyCode key) => this.keyboard.getAxis(key);

    [LineNumberTable(49)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mouseScreen(float x, float y) => Core.camera.project(this.mouseReturn.set(x, y));

    [LineNumberTable(194)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyDown(KeyBinds.KeyBind key) => Core.keybinds.get(key).key != null && this.keyboard.isPressed(Core.keybinds.get(key).key);

    [LineNumberTable(44)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mouseWorld(float x, float y) => Core.camera.unproject(this.mouseReturn.set(x, y));

    [LineNumberTable(64)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec2 mouseWorld() => Core.camera.unproject(this.mouse());

    [LineNumberTable(new byte[] {160, 207, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeProcessor(InputProcessor processor) => this.inputMultiplexer.removeProcessor(processor);

    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float mouseWorldX() => Core.camera.unproject(this.mouse()).x;

    [LineNumberTable(59)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float mouseWorldY() => Core.camera.unproject(this.mouse()).y;

    [LineNumberTable(204)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool keyRelease(KeyBinds.KeyBind key) => Core.keybinds.get(key).key != null && this.keyboard.isReleased(Core.keybinds.get(key).key);

    [LineNumberTable(new byte[] {160, 107, 108, 104, 147})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float axisTap(KeyBinds.KeyBind key)
    {
      KeyBinds.Axis axis = Core.keybinds.get(key);
      if (axis.key != null)
        return this.keyboard.getAxis(axis.key);
      if (this.keyboard.isTapped(axis.min))
        return -1f;
      return this.keyboard.isTapped(axis.max) ? 1f : 0.0f;
    }

    public abstract bool isTouched();

    public abstract bool isTouched(int i);

    [Signature("()Larc/struct/Seq<Larc/input/InputDevice;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getDevices() => this.devices;

    [LineNumberTable(new byte[] {73, 98, 103, 45, 166})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getTouches()
    {
      int num = 0;
      for (int i = 0; i < 10; ++i)
      {
        if (this.isTouched(i))
          ++num;
      }
      return num;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setOnscreenKeyboardVisible(bool visible)
    {
    }

    [LineNumberTable(154)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPressure(int pointer) => this.isTouched(pointer) ? 1f : 0.0f;

    [LineNumberTable(new byte[] {159, 170, 200, 139, 154, 154, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Input()
    {
      Input input = this;
      this.keyboard = new KeyboardDevice();
      this.devices = Seq.with((object[]) new InputDevice[1]
      {
        (InputDevice) this.keyboard
      });
      this.inputMultiplexer = new InputMultiplexer(new InputProcessor[1]
      {
        (InputProcessor) this.keyboard
      });
      this.caughtKeys = new IntSet();
      this.mouseReturn = new Vec2();
    }

    public abstract int mouseX(int i);

    public abstract int deltaX();

    public abstract int deltaX(int i);

    public abstract int mouseY(int i);

    public abstract int deltaY();

    public abstract int deltaY(int i);

    public abstract bool justTouched();

    [LineNumberTable(142)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getPressure() => this.getPressure(0);

    [LineNumberTable(159)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool shift() => this.keyDown(KeyCode.__\u003C\u003EshiftLeft) || this.keyDown(KeyCode.__\u003C\u003EshiftRight);

    [LineNumberTable(169)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool alt() => this.keyDown(KeyCode.__\u003C\u003EaltLeft) || this.keyDown(KeyCode.__\u003C\u003EaltRight);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void vibrate(int milliseconds)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void vibrate(long[] pattern, int repeat)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void cancelVibrate()
    {
    }

    [LineNumberTable(267)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getAccelerometer() => Vec3.__\u003C\u003EZero;

    [LineNumberTable(272)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getGyroscope() => Vec3.__\u003C\u003EZero;

    [LineNumberTable(277)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Vec3 getOrientation() => Vec3.__\u003C\u003EZero;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getRotationMatrix(float[] matrix)
    {
    }

    public abstract long getCurrentEventTime();

    [LineNumberTable(307)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCatch(KeyCode code) => this.caughtKeys.contains(code.ordinal());

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual InputMultiplexer getInputMultiplexer() => this.inputMultiplexer;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual KeyboardDevice getKeyboard() => this.keyboard;

    [LineNumberTable(353)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isPeripheralAvailable(Input.Peripheral peripheral) => object.ReferenceEquals((object) peripheral, (object) Input.Peripheral.__\u003C\u003EhardwareKeyboard);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getRotation() => 0;

    [LineNumberTable(363)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Input.Orientation getNativeOrientation() => Input.Orientation.__\u003C\u003Elandscape;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isCursorCatched() => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCursorCatched(bool catched)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setCursorPosition(int x, int y)
    {
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/Input$Orientation;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Orientation : Enum
    {
      [Modifiers]
      internal static Input.Orientation __\u003C\u003Elandscape;
      [Modifiers]
      internal static Input.Orientation __\u003C\u003Eportrait;
      [Modifiers]
      private static Input.Orientation[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Orientation([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Input.Orientation[] values() => (Input.Orientation[]) Input.Orientation.\u0024VALUES.Clone();

      [LineNumberTable(387)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Input.Orientation valueOf(string name) => (Input.Orientation) Enum.valueOf((Class) ClassLiteral<Input.Orientation>.Value, name);

      [LineNumberTable(new byte[] {159, 45, 77, 63, 1})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Orientation()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.Input$Orientation"))
          return;
        Input.Orientation.__\u003C\u003Elandscape = new Input.Orientation(nameof (landscape), 0);
        Input.Orientation.__\u003C\u003Eportrait = new Input.Orientation(nameof (portrait), 1);
        Input.Orientation.\u0024VALUES = new Input.Orientation[2]
        {
          Input.Orientation.__\u003C\u003Elandscape,
          Input.Orientation.__\u003C\u003Eportrait
        };
      }

      [Modifiers]
      public static Input.Orientation landscape
      {
        [HideFromJava] get => Input.Orientation.__\u003C\u003Elandscape;
      }

      [Modifiers]
      public static Input.Orientation portrait
      {
        [HideFromJava] get => Input.Orientation.__\u003C\u003Eportrait;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        landscape,
        portrait,
      }
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/Input$Peripheral;>;")]
    [Modifiers]
    [Serializable]
    public sealed class Peripheral : Enum
    {
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003EhardwareKeyboard;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003EonscreenKeyboard;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003EmultitouchScreen;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003Eaccelerometer;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003Ecompass;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003Evibrator;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003Egyroscope;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003ErotationVector;
      [Modifiers]
      internal static Input.Peripheral __\u003C\u003Epressure;
      [Modifiers]
      private static Input.Peripheral[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(392)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private Peripheral([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(392)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Input.Peripheral[] values() => (Input.Peripheral[]) Input.Peripheral.\u0024VALUES.Clone();

      [LineNumberTable(392)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static Input.Peripheral valueOf(string name) => (Input.Peripheral) Enum.valueOf((Class) ClassLiteral<Input.Peripheral>.Value, name);

      [LineNumberTable(new byte[] {159, 44, 109, 63, 113})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static Peripheral()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.Input$Peripheral"))
          return;
        Input.Peripheral.__\u003C\u003EhardwareKeyboard = new Input.Peripheral(nameof (hardwareKeyboard), 0);
        Input.Peripheral.__\u003C\u003EonscreenKeyboard = new Input.Peripheral(nameof (onscreenKeyboard), 1);
        Input.Peripheral.__\u003C\u003EmultitouchScreen = new Input.Peripheral(nameof (multitouchScreen), 2);
        Input.Peripheral.__\u003C\u003Eaccelerometer = new Input.Peripheral(nameof (accelerometer), 3);
        Input.Peripheral.__\u003C\u003Ecompass = new Input.Peripheral(nameof (compass), 4);
        Input.Peripheral.__\u003C\u003Evibrator = new Input.Peripheral(nameof (vibrator), 5);
        Input.Peripheral.__\u003C\u003Egyroscope = new Input.Peripheral(nameof (gyroscope), 6);
        Input.Peripheral.__\u003C\u003ErotationVector = new Input.Peripheral(nameof (rotationVector), 7);
        Input.Peripheral.__\u003C\u003Epressure = new Input.Peripheral(nameof (pressure), 8);
        Input.Peripheral.\u0024VALUES = new Input.Peripheral[9]
        {
          Input.Peripheral.__\u003C\u003EhardwareKeyboard,
          Input.Peripheral.__\u003C\u003EonscreenKeyboard,
          Input.Peripheral.__\u003C\u003EmultitouchScreen,
          Input.Peripheral.__\u003C\u003Eaccelerometer,
          Input.Peripheral.__\u003C\u003Ecompass,
          Input.Peripheral.__\u003C\u003Evibrator,
          Input.Peripheral.__\u003C\u003Egyroscope,
          Input.Peripheral.__\u003C\u003ErotationVector,
          Input.Peripheral.__\u003C\u003Epressure
        };
      }

      [Modifiers]
      public static Input.Peripheral hardwareKeyboard
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003EhardwareKeyboard;
      }

      [Modifiers]
      public static Input.Peripheral onscreenKeyboard
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003EonscreenKeyboard;
      }

      [Modifiers]
      public static Input.Peripheral multitouchScreen
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003EmultitouchScreen;
      }

      [Modifiers]
      public static Input.Peripheral accelerometer
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003Eaccelerometer;
      }

      [Modifiers]
      public static Input.Peripheral compass
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003Ecompass;
      }

      [Modifiers]
      public static Input.Peripheral vibrator
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003Evibrator;
      }

      [Modifiers]
      public static Input.Peripheral gyroscope
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003Egyroscope;
      }

      [Modifiers]
      public static Input.Peripheral rotationVector
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003ErotationVector;
      }

      [Modifiers]
      public static Input.Peripheral pressure
      {
        [HideFromJava] get => Input.Peripheral.__\u003C\u003Epressure;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        hardwareKeyboard,
        onscreenKeyboard,
        multitouchScreen,
        accelerometer,
        compass,
        vibrator,
        gyroscope,
        rotationVector,
        pressure,
      }
    }

    public class TextInput : Object
    {
      public bool multiline;
      public string title;
      public string text;
      public bool numeric;
      [Signature("Larc/func/Cons<Ljava/lang/String;>;")]
      public Cons accepted;
      public Runnable canceled;
      public int maxLength;

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240([In] string obj0)
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00241()
      {
      }

      [LineNumberTable(new byte[] {161, 27, 104, 103, 107, 139, 112, 112})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public TextInput()
      {
        Input.TextInput textInput = this;
        this.multiline = false;
        this.title = "";
        this.text = "";
        this.accepted = (Cons) new Input.TextInput.__\u003C\u003EAnon0();
        this.canceled = (Runnable) new Input.TextInput.__\u003C\u003EAnon1();
        this.maxLength = -1;
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon0 : Cons
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public void get([In] object obj0) => Input.TextInput.lambda\u0024new\u00240((string) obj0);
      }

      [SpecialName]
      private sealed class __\u003C\u003EAnon1 : Runnable
      {
        internal __\u003C\u003EAnon1()
        {
        }

        public void run() => Input.TextInput.lambda\u0024new\u00241();
      }
    }
  }
}
