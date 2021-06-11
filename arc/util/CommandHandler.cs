// Decompiled with JetBrains decompiler
// Type: arc.util.CommandHandler
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.func;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc.util
{
  public class CommandHandler : Object
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/util/CommandHandler$Command;>;")]
    private ObjectMap commands;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/util/CommandHandler$Command;>;")]
    private Seq orderedCommands;
    private string prefix;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getPrefix() => this.prefix;

    [LineNumberTable(new byte[] {159, 177, 113, 141, 147, 127, 20, 159, 20, 135, 147, 103, 99, 163, 116, 110, 141, 127, 19, 163, 113, 104, 165, 109, 101, 100, 142, 104, 130, 107, 112, 169, 102, 133, 127, 0, 174, 158, 142})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CommandHandler.CommandResponse handleMessage(
      string message,
      object @params)
    {
      if (message == null || !String.instancehelper_startsWith(message, this.prefix))
        return new CommandHandler.CommandResponse(CommandHandler.ResponseType.__\u003C\u003EnoCommand, (CommandHandler.Command) null, (string) null);
      message = String.instancehelper_substring(message, String.instancehelper_length(this.prefix));
      string str1 = message;
      object obj1 = (object) " ";
      CharSequence charSequence1;
      charSequence1.__\u003Cref\u003E = (__Null) obj1;
      CharSequence charSequence2 = charSequence1;
      string runCommand = !String.instancehelper_contains(str1, charSequence2) ? message : String.instancehelper_substring(message, 0, String.instancehelper_indexOf(message, " "));
      string str2 = message;
      object obj2 = (object) " ";
      charSequence1.__\u003Cref\u003E = (__Null) obj2;
      CharSequence charSequence3 = charSequence1;
      string str3 = !String.instancehelper_contains(str2, charSequence3) ? "" : String.instancehelper_substring(message, String.instancehelper_length(runCommand) + 1);
      Seq seq = new Seq();
      CommandHandler.Command command = (CommandHandler.Command) this.commands.get((object) runCommand);
      if (command == null)
        return new CommandHandler.CommandResponse(CommandHandler.ResponseType.__\u003C\u003EunknownCommand, (CommandHandler.Command) null, runCommand);
      int index = 0;
      int num1 = 0;
      for (; index < command.__\u003C\u003Eparams.Length || String.instancehelper_isEmpty(str3); ++index)
      {
        if (!String.instancehelper_isEmpty(str3))
        {
          if (command.__\u003C\u003Eparams[index].__\u003C\u003Eoptional || index >= command.__\u003C\u003Eparams.Length - 1 || command.__\u003C\u003Eparams[index + 1].__\u003C\u003Eoptional)
            num1 = 1;
          if (command.__\u003C\u003Eparams[index].__\u003C\u003Evariadic)
          {
            seq.add((object) str3);
          }
          else
          {
            int num2 = String.instancehelper_indexOf(str3, " ");
            if (num2 == -1)
            {
              if (num1 == 0)
                return new CommandHandler.CommandResponse(CommandHandler.ResponseType.__\u003C\u003EfewArguments, command, runCommand);
              seq.add((object) str3);
            }
            else
            {
              string str4 = String.instancehelper_substring(str3, 0, num2);
              str3 = String.instancehelper_substring(str3, String.instancehelper_length(str4) + 1);
              seq.add((object) str4);
              continue;
            }
          }
        }
        if (num1 == 0 && command.__\u003C\u003Eparams.Length > 0 && !command.__\u003C\u003Eparams[0].__\u003C\u003Eoptional)
          return new CommandHandler.CommandResponse(CommandHandler.ResponseType.__\u003C\u003EfewArguments, command, runCommand);
        command.runner.accept((string[]) seq.toArray((Class) ClassLiteral<String>.Value), @params);
        return new CommandHandler.CommandResponse(CommandHandler.ResponseType.__\u003C\u003Evalid, command, runCommand);
      }
      return new CommandHandler.CommandResponse(CommandHandler.ResponseType.__\u003C\u003EmanyArguments, command, runCommand);
    }

    [LineNumberTable(new byte[] {159, 157, 232, 59, 107, 235, 69, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public CommandHandler(string prefix)
    {
      CommandHandler commandHandler = this;
      this.commands = new ObjectMap();
      this.orderedCommands = new Seq();
      this.prefix = prefix;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Larc/util/CommandHandler$CommandRunner<TT;>;)Larc/util/CommandHandler$Command;")]
    [LineNumberTable(new byte[] {67, 107, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CommandHandler.Command register(
      string text,
      string @params,
      string description,
      CommandHandler.CommandRunner runner)
    {
      CommandHandler.Command command = new CommandHandler.Command(text, @params, description, runner);
      this.commands.put((object) String.instancehelper_toLowerCase(text), (object) command);
      this.orderedCommands.add((object) command);
      return command;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/String;Larc/util/CommandHandler$CommandRunner<TT;>;)Larc/util/CommandHandler$Command;")]
    [LineNumberTable(new byte[] {52, 110, 115, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CommandHandler.Command register(
      string text,
      string description,
      CommandHandler.CommandRunner runner)
    {
      CommandHandler.Command command = new CommandHandler.Command(text, "", description, runner);
      this.commands.put((object) String.instancehelper_toLowerCase(text), (object) command);
      this.orderedCommands.add((object) command);
      return command;
    }

    [Signature("()Larc/struct/Seq<Larc/util/CommandHandler$Command;>;")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getCommandList() => this.orderedCommands;

    [Modifiers]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024register\u00240([In] Cons obj0, [In] string[] obj1, [In] object obj2) => obj0.get((object) obj1);

    [Modifiers]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024register\u00241([In] Cons obj0, [In] string[] obj1, [In] object obj2) => obj0.get((object) obj1);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setPrefix(string prefix) => this.prefix = prefix;

    [LineNumberTable(29)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CommandHandler.CommandResponse handleMessage(string message) => this.handleMessage(message, (object) null);

    [LineNumberTable(new byte[] {44, 114, 100, 109, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void removeCommand(string text)
    {
      CommandHandler.Command command = (CommandHandler.Command) this.commands.get((object) text);
      if (command == null)
        return;
      this.commands.remove((object) text);
      this.orderedCommands.remove((object) command);
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<[Ljava/lang/String;>;)Larc/util/CommandHandler$Command;")]
    [LineNumberTable(124)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CommandHandler.Command register(
      string text,
      string description,
      Cons runner)
    {
      return this.register(text, description, (CommandHandler.CommandRunner) new CommandHandler.__\u003C\u003EAnon0(runner));
    }

    [Signature("(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Larc/func/Cons<[Ljava/lang/String;>;)Larc/util/CommandHandler$Command;")]
    [LineNumberTable(128)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual CommandHandler.Command register(
      string text,
      string @params,
      string description,
      Cons runner)
    {
      return this.register(text, @params, description, (CommandHandler.CommandRunner) new CommandHandler.__\u003C\u003EAnon1(runner));
    }

    public class Command : Object
    {
      internal string __\u003C\u003Etext;
      internal string __\u003C\u003EparamText;
      internal string __\u003C\u003Edescription;
      internal CommandHandler.CommandParam[] __\u003C\u003Eparams;
      [Modifiers]
      internal CommandHandler.CommandRunner runner;

      [LineNumberTable(new byte[] {96, 104, 103, 103, 104, 135, 108, 104, 145, 141, 130, 111, 133, 159, 27, 124, 131, 108, 99, 112, 101, 108, 133, 191, 17, 134, 115, 110, 108, 144, 115, 163, 243, 35, 233, 97})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public Command(
        string text,
        string paramText,
        string description,
        CommandHandler.CommandRunner runner)
      {
        CommandHandler.Command command = this;
        this.__\u003C\u003Etext = text;
        this.__\u003C\u003EparamText = paramText;
        this.runner = runner;
        this.__\u003C\u003Edescription = description;
        string[] strArray = String.instancehelper_split(paramText, " ");
        if (String.instancehelper_length(paramText) == 0)
        {
          this.__\u003C\u003Eparams = new CommandHandler.CommandParam[0];
        }
        else
        {
          this.__\u003C\u003Eparams = new CommandHandler.CommandParam[strArray.Length];
          int num1 = 0;
          for (int index = 0; index < this.__\u003C\u003Eparams.Length; ++index)
          {
            string str1 = strArray[index];
            if (String.instancehelper_length(str1) <= 2)
            {
              string str2 = new StringBuilder().append("Malformed param '").append(str1).append("'").toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str2);
            }
            int num2 = (int) String.instancehelper_charAt(str1, 0);
            int num3 = (int) String.instancehelper_charAt(str1, String.instancehelper_length(str1) - 1);
            int num4 = 0;
            int num5;
            if (num2 == 60 && num3 == 62)
            {
              if (num1 != 0)
              {
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new IllegalArgumentException("Can't have non-optional param after optional param!");
              }
              num5 = 0;
            }
            else if (num2 == 91 && num3 == 93)
            {
              num5 = 1;
            }
            else
            {
              string str2 = new StringBuilder().append("Malformed param '").append(str1).append("'").toString();
              Throwable.__\u003CsuppressFillInStackTrace\u003E();
              throw new IllegalArgumentException(str2);
            }
            if (num5 != 0)
              num1 = 1;
            string name = String.instancehelper_substring(str1, 1, String.instancehelper_length(str1) - 1);
            if (String.instancehelper_endsWith(name, "..."))
            {
              if (index != this.__\u003C\u003Eparams.Length - 1)
              {
                Throwable.__\u003CsuppressFillInStackTrace\u003E();
                throw new IllegalArgumentException("A variadic parameter should be the last parameter!");
              }
              name = String.instancehelper_substring(name, 0, String.instancehelper_length(name) - 3);
              num4 = 1;
            }
            this.__\u003C\u003Eparams[index] = new CommandHandler.CommandParam(name, num5 != 0, num4 != 0);
          }
        }
      }

      [Modifiers]
      public string text
      {
        [HideFromJava] get => this.__\u003C\u003Etext;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etext = value;
      }

      [Modifiers]
      public string paramText
      {
        [HideFromJava] get => this.__\u003C\u003EparamText;
        [HideFromJava] [param: In] private set => this.__\u003C\u003EparamText = value;
      }

      [Modifiers]
      public string description
      {
        [HideFromJava] get => this.__\u003C\u003Edescription;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Edescription = value;
      }

      [Modifiers]
      public CommandHandler.CommandParam[] @params
      {
        [HideFromJava] get => this.__\u003C\u003Eparams;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eparams = value;
      }
    }

    public class CommandParam : Object
    {
      internal string __\u003C\u003Ename;
      internal bool __\u003C\u003Eoptional;
      internal bool __\u003C\u003Evariadic;

      [LineNumberTable(new byte[] {159, 91, 100, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CommandParam(string name, bool optional, bool variadic)
      {
        int num1 = optional ? 1 : 0;
        int num2 = variadic ? 1 : 0;
        // ISSUE: explicit constructor call
        base.\u002Ector();
        CommandHandler.CommandParam commandParam = this;
        this.__\u003C\u003Ename = name;
        this.__\u003C\u003Eoptional = num1 != 0;
        this.__\u003C\u003Evariadic = num2 != 0;
      }

      [Modifiers]
      public string name
      {
        [HideFromJava] get => this.__\u003C\u003Ename;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ename = value;
      }

      [Modifiers]
      public bool optional
      {
        [HideFromJava] get => this.__\u003C\u003Eoptional;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Eoptional = value;
      }

      [Modifiers]
      public bool variadic
      {
        [HideFromJava] get => this.__\u003C\u003Evariadic;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Evariadic = value;
      }
    }

    public class CommandResponse : Object
    {
      internal CommandHandler.ResponseType __\u003C\u003Etype;
      internal CommandHandler.Command __\u003C\u003Ecommand;
      internal string __\u003C\u003ErunCommand;

      [LineNumberTable(new byte[] {160, 103, 104, 103, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public CommandResponse(
        CommandHandler.ResponseType type,
        CommandHandler.Command command,
        string runCommand)
      {
        CommandHandler.CommandResponse commandResponse = this;
        this.__\u003C\u003Etype = type;
        this.__\u003C\u003Ecommand = command;
        this.__\u003C\u003ErunCommand = runCommand;
      }

      [Modifiers]
      public CommandHandler.ResponseType type
      {
        [HideFromJava] get => this.__\u003C\u003Etype;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Etype = value;
      }

      [Modifiers]
      public CommandHandler.Command command
      {
        [HideFromJava] get => this.__\u003C\u003Ecommand;
        [HideFromJava] [param: In] private set => this.__\u003C\u003Ecommand = value;
      }

      [Modifiers]
      public string runCommand
      {
        [HideFromJava] get => this.__\u003C\u003ErunCommand;
        [HideFromJava] [param: In] private set => this.__\u003C\u003ErunCommand = value;
      }
    }

    [Signature("<T:Ljava/lang/Object;>Ljava/lang/Object;")]
    public interface CommandRunner
    {
      [Signature("([Ljava/lang/String;TT;)V")]
      void accept(string[] strarr, object obj);
    }

    [InnerClass]
    [Signature("Ljava/lang/Enum<Larc/util/CommandHandler$ResponseType;>;")]
    [Modifiers]
    [Serializable]
    public sealed class ResponseType : Enum
    {
      [Modifiers]
      internal static CommandHandler.ResponseType __\u003C\u003EnoCommand;
      [Modifiers]
      internal static CommandHandler.ResponseType __\u003C\u003EunknownCommand;
      [Modifiers]
      internal static CommandHandler.ResponseType __\u003C\u003EfewArguments;
      [Modifiers]
      internal static CommandHandler.ResponseType __\u003C\u003EmanyArguments;
      [Modifiers]
      internal static CommandHandler.ResponseType __\u003C\u003Evalid;
      [Modifiers]
      private static CommandHandler.ResponseType[] \u0024VALUES;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static void __\u003Cclinit\u003E()
      {
      }

      [Signature("()V")]
      [LineNumberTable(135)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private ResponseType([In] string obj0, [In] int obj1)
        : base(obj0, obj1)
      {
        GC.KeepAlive((object) this);
      }

      [LineNumberTable(135)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static CommandHandler.ResponseType[] values() => (CommandHandler.ResponseType[]) CommandHandler.ResponseType.\u0024VALUES.Clone();

      [LineNumberTable(135)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public static CommandHandler.ResponseType valueOf(string name) => (CommandHandler.ResponseType) Enum.valueOf((Class) ClassLiteral<CommandHandler.ResponseType>.Value, name);

      [LineNumberTable(new byte[] {159, 108, 77, 63, 49})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      static ResponseType()
      {
        if (ByteCodeHelper.isAlreadyInited("arc.util.CommandHandler$ResponseType"))
          return;
        CommandHandler.ResponseType.__\u003C\u003EnoCommand = new CommandHandler.ResponseType(nameof (noCommand), 0);
        CommandHandler.ResponseType.__\u003C\u003EunknownCommand = new CommandHandler.ResponseType(nameof (unknownCommand), 1);
        CommandHandler.ResponseType.__\u003C\u003EfewArguments = new CommandHandler.ResponseType(nameof (fewArguments), 2);
        CommandHandler.ResponseType.__\u003C\u003EmanyArguments = new CommandHandler.ResponseType(nameof (manyArguments), 3);
        CommandHandler.ResponseType.__\u003C\u003Evalid = new CommandHandler.ResponseType(nameof (valid), 4);
        CommandHandler.ResponseType.\u0024VALUES = new CommandHandler.ResponseType[5]
        {
          CommandHandler.ResponseType.__\u003C\u003EnoCommand,
          CommandHandler.ResponseType.__\u003C\u003EunknownCommand,
          CommandHandler.ResponseType.__\u003C\u003EfewArguments,
          CommandHandler.ResponseType.__\u003C\u003EmanyArguments,
          CommandHandler.ResponseType.__\u003C\u003Evalid
        };
      }

      [Modifiers]
      public static CommandHandler.ResponseType noCommand
      {
        [HideFromJava] get => CommandHandler.ResponseType.__\u003C\u003EnoCommand;
      }

      [Modifiers]
      public static CommandHandler.ResponseType unknownCommand
      {
        [HideFromJava] get => CommandHandler.ResponseType.__\u003C\u003EunknownCommand;
      }

      [Modifiers]
      public static CommandHandler.ResponseType fewArguments
      {
        [HideFromJava] get => CommandHandler.ResponseType.__\u003C\u003EfewArguments;
      }

      [Modifiers]
      public static CommandHandler.ResponseType manyArguments
      {
        [HideFromJava] get => CommandHandler.ResponseType.__\u003C\u003EmanyArguments;
      }

      [Modifiers]
      public static CommandHandler.ResponseType valid
      {
        [HideFromJava] get => CommandHandler.ResponseType.__\u003C\u003Evalid;
      }

      [HideFromJava]
      [Serializable]
      public enum __Enum
      {
        noCommand,
        unknownCommand,
        fewArguments,
        manyArguments,
        valid,
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : CommandHandler.CommandRunner
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon0([In] Cons obj0) => this.arg\u00241 = obj0;

      public void accept([In] string[] obj0, [In] object obj1) => CommandHandler.lambda\u0024register\u00240(this.arg\u00241, obj0, obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : CommandHandler.CommandRunner
    {
      private readonly Cons arg\u00241;

      internal __\u003C\u003EAnon1([In] Cons obj0) => this.arg\u00241 = obj0;

      public void accept([In] string[] obj0, [In] object obj1) => CommandHandler.lambda\u0024register\u00241(this.arg\u00241, obj0, obj1);
    }
  }
}
