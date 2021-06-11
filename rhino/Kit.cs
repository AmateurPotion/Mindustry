// Decompiled with JetBrains decompiler
// Type: rhino.Kit
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace rhino
{
  public class Kit : Object
  {
    [SpecialName]
    private static CallerID __\u003CcallerID\u003E;

    [Throws(new string[] {"java.lang.RuntimeException"})]
    [LineNumberTable(new byte[] {160, 226, 139, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException codeBug()
    {
      IllegalStateException illegalStateException = new IllegalStateException("FAILED ASSERTION");
      Throwable.instancehelper_printStackTrace((Exception) illegalStateException, java.lang.System.err);
      throw Throwable.__\u003Cunmap\u003E((Exception) illegalStateException);
    }

    [Signature("(Ljava/util/Map<Ljava/lang/Object;Ljava/lang/Object;>;Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {160, 134, 104, 104, 99, 139, 131, 111})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object initHash([In] Map obj0, [In] object obj1, [In] object obj2)
    {
      lock (obj0)
      {
        object obj = obj0.get(obj1);
        if (obj == null)
          obj0.put(obj1, obj2);
        else
          obj2 = obj;
      }
      return obj2;
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 179, 105, 107, 139, 115, 141, 118, 95, 28, 63, 21, 231, 57, 237, 72})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string readReader(Reader reader)
    {
      BufferedReader bufferedReader = new BufferedReader(reader);
      Exception exception1 = (Exception) null;
      string str;
      Exception exception2;
      // ISSUE: fault handler
      try
      {
        char[] chArray = new char[1024];
        StringBuilder stringBuilder = new StringBuilder(1024);
        int num;
        while ((num = bufferedReader.read(chArray, 0, 1024)) != -1)
          stringBuilder.append(chArray, 0, num);
        str = stringBuilder.toString();
        goto label_14;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      __fault
      {
        if (bufferedReader != null)
        {
          if (exception1 != null)
          {
            Exception exception3;
            try
            {
              bufferedReader.close();
              goto label_12;
            }
            catch (Exception ex)
            {
              exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception4 = exception3;
            Throwable.instancehelper_addSuppressed(exception1, exception4);
          }
          else
            bufferedReader.close();
        }
label_12:;
      }
      Exception exception5 = exception2;
      Exception exception6;
      // ISSUE: fault handler
      try
      {
        Exception exception3 = exception5;
        exception6 = exception3;
        throw Throwable.__\u003Cunmap\u003E(exception3);
      }
      __fault
      {
        if (bufferedReader != null)
        {
          if (exception6 != null)
          {
            Exception exception3;
            try
            {
              bufferedReader.close();
              goto label_28;
            }
            catch (Exception ex)
            {
              exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
            }
            Exception exception4 = exception3;
            Throwable.instancehelper_addSuppressed(exception6, exception4);
          }
          else
            bufferedReader.close();
        }
label_28:;
      }
label_14:
      if (bufferedReader != null)
      {
        if (null != null)
        {
          Exception exception3;
          try
          {
            bufferedReader.close();
            goto label_20;
          }
          catch (Exception ex)
          {
            exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          }
          Throwable.instancehelper_addSuppressed((Exception) null, exception3);
        }
        else
          bufferedReader.close();
      }
label_20:
      return str;
    }

    [LineNumberTable(new byte[] {159, 191, 102, 237, 69})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static bool testIfCanLoadRhinoClasses([In] ClassLoader obj0)
    {
      Class contextFactoryClass = ScriptRuntime.__\u003C\u003EContextFactoryClass;
      return object.ReferenceEquals((object) Kit.classOrNull(obj0, contextFactoryClass.getName()), (object) contextFactoryClass);
    }

    [Signature("(Ljava/lang/Class<*>;)Ljava/lang/Object;")]
    [LineNumberTable(new byte[] {159, 181, 127, 20, 129})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static object newInstanceOrNull([In] Class obj0)
    {
      object obj;
      try
      {
        try
        {
          try
          {
            try
            {
              obj = obj0.newInstance(Kit.__\u003CGetCallerID\u003E());
            }
            catch (SecurityException ex)
            {
              goto label_7;
            }
          }
          catch (IllegalAccessException ex)
          {
            goto label_8;
          }
        }
        catch (InstantiationException ex)
        {
          goto label_9;
        }
      }
      catch (Exception ex)
      {
        if (ByteCodeHelper.MapException<LinkageError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
          throw;
        else
          goto label_10;
      }
      return obj;
label_7:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_11;
label_8:
      local = null;
      goto label_11;
label_9:
      local = null;
      goto label_11;
label_10:
      local = null;
label_11:
      return (object) null;
    }

    [Signature("(Ljava/lang/String;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {159, 155, 127, 20, 193, 226, 61, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Class classOrNull(string className)
    {
      Class @class;
      try
      {
        try
        {
          try
          {
            try
            {
              @class = Class.forName(className, Kit.__\u003CGetCallerID\u003E());
            }
            catch (ClassNotFoundException ex)
            {
              goto label_7;
            }
          }
          catch (Exception ex)
          {
            if (ByteCodeHelper.MapException<LinkageError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
              throw;
            else
              goto label_8;
          }
        }
        catch (SecurityException ex)
        {
          goto label_9;
        }
      }
      catch (IllegalArgumentException ex)
      {
        goto label_10;
      }
      return @class;
label_7:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_11;
label_8:
      local = null;
      goto label_11;
label_9:
      local = null;
      goto label_11;
label_10:
      goto label_12;
label_11:
label_12:
      return (Class) null;
    }

    [LineNumberTable(new byte[] {160, 105, 99, 99, 98, 104, 98, 140, 112, 100, 100, 104, 110, 130, 140, 164, 108, 99, 111, 100, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object getListener(object bag, int index)
    {
      switch (index)
      {
        case 0:
          if (bag == null)
            return (object) null;
          if (!(bag is object[]))
            return bag;
          object[] objArray1 = (object[]) bag;
          if (objArray1.Length < 2)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException();
          }
          return objArray1[0];
        case 1:
          if (bag is object[])
            return ((object[]) bag)[1];
          if (bag == null)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException();
          }
          return (object) null;
        default:
          object[] objArray2 = (object[]) bag;
          int length = objArray2.Length;
          if (length < 2)
          {
            Throwable.__\u003CsuppressFillInStackTrace\u003E();
            throw new IllegalArgumentException();
          }
          return index == length ? (object) null : objArray2[index];
      }
    }

    [LineNumberTable(new byte[] {86, 110, 147, 99, 104, 104, 146, 108, 131, 111, 105, 106, 100, 163})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object addListener(object bag, object listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (listener is object[])
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (bag == null)
        bag = listener;
      else if (!(bag is object[]))
      {
        bag = (object) new object[2]{ bag, listener };
      }
      else
      {
        object[] objArray1 = (object[]) bag;
        int length = objArray1.Length;
        if (length < 2)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        object[] objArray2 = new object[length + 1];
        ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray2, 0, length);
        objArray2[length] = listener;
        bag = (object) objArray2;
      }
      return bag;
    }

    [LineNumberTable(new byte[] {123, 110, 147, 105, 104, 107, 108, 131, 111, 100, 107, 106, 110, 170, 130, 100, 107, 105, 106, 112, 99, 130, 195})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object removeListener(object bag, object listener)
    {
      if (listener == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (listener is object[])
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (object.ReferenceEquals(bag, listener))
        bag = (object) null;
      else if (bag is object[])
      {
        object[] objArray1 = (object[]) bag;
        int length = objArray1.Length;
        if (length < 2)
        {
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException();
        }
        if (length == 2)
        {
          if (object.ReferenceEquals(objArray1[1], listener))
            bag = objArray1[0];
          else if (object.ReferenceEquals(objArray1[0], listener))
            bag = objArray1[1];
        }
        else
        {
          int index = length;
          do
          {
            index += -1;
            if (object.ReferenceEquals(objArray1[index], listener))
            {
              object[] objArray2 = new object[length - 1];
              ByteCodeHelper.arraycopy((object) objArray1, 0, (object) objArray2, 0, index);
              ByteCodeHelper.arraycopy((object) objArray1, index + 1, (object) objArray2, index, length - (index + 1));
              bag = (object) objArray2;
              break;
            }
          }
          while (index != 0);
        }
      }
      return bag;
    }

    [Throws(new string[] {"java.lang.RuntimeException"})]
    [LineNumberTable(new byte[] {160, 240, 124, 135, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static RuntimeException codeBug(string msg)
    {
      msg = new StringBuilder().append("FAILED ASSERTION: ").append(msg).toString();
      IllegalStateException illegalStateException = new IllegalStateException(msg);
      Throwable.instancehelper_printStackTrace((Exception) illegalStateException, java.lang.System.err);
      throw Throwable.__\u003Cunmap\u003E((Exception) illegalStateException);
    }

    [Signature("(Ljava/lang/ClassLoader;Ljava/lang/String;)Ljava/lang/Class<*>;")]
    [LineNumberTable(new byte[] {159, 170, 127, 16, 193, 226, 61, 193})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Class classOrNull(ClassLoader loader, string className)
    {
      Class @class;
      try
      {
        try
        {
          try
          {
            try
            {
              @class = loader.loadClass(className);
            }
            catch (ClassNotFoundException ex)
            {
              goto label_7;
            }
          }
          catch (Exception ex)
          {
            if (ByteCodeHelper.MapException<LinkageError>(ex, (ByteCodeHelper.MapFlags) 2) == null)
              throw;
            else
              goto label_8;
          }
        }
        catch (SecurityException ex)
        {
          goto label_9;
        }
      }
      catch (IllegalArgumentException ex)
      {
        goto label_10;
      }
      return @class;
label_7:
      // ISSUE: variable of the null type
      __Null local = null;
      goto label_11;
label_8:
      local = null;
      goto label_11;
label_9:
      local = null;
      goto label_11;
label_10:
      goto label_12;
label_11:
label_12:
      return (Class) null;
    }

    [LineNumberTable(10)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Kit()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int xDigitToInt(int c, int accumulator)
    {
      if (c <= 57)
      {
        c += -48;
        if (0 <= c)
          goto label_8;
      }
      else if (c <= 70)
      {
        if (65 <= c)
        {
          c += -55;
          goto label_8;
        }
      }
      else if (c <= 102 && 97 <= c)
      {
        c += -87;
        goto label_8;
      }
      return -1;
label_8:
      return accumulator << 4 | c;
    }

    [LineNumberTable(new byte[] {160, 173, 110, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static object makeHashKeyFromPair(object key1, object key2)
    {
      if (key1 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      if (key2 == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException();
      }
      return (object) new Kit.ComplexKey(key1, key2);
    }

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {160, 192, 100, 191, 6, 103, 130, 109, 100, 130, 100, 101, 106, 106, 130, 98, 101, 104, 107, 131})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static byte[] readStream(InputStream @is, int initialBufferCapacity)
    {
      if (initialBufferCapacity <= 0)
      {
        string str = new StringBuilder().append("Bad initialBufferCapacity: ").append(initialBufferCapacity).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException(str);
      }
      byte[] numArray1 = new byte[initialBufferCapacity];
      int length = 0;
      while (true)
      {
        do
        {
          int num = @is.read(numArray1, length, numArray1.Length - length);
          if (num >= 0)
            length += num;
          else
            goto label_6;
        }
        while (length != numArray1.Length);
        byte[] numArray2 = new byte[numArray1.Length * 2];
        ByteCodeHelper.arraycopy_primitive_1((Array) numArray1, 0, (Array) numArray2, 0, length);
        numArray1 = numArray2;
      }
label_6:
      if (length != numArray1.Length)
      {
        byte[] numArray2 = new byte[length];
        ByteCodeHelper.arraycopy_primitive_1((Array) numArray1, 0, (Array) numArray2, 0, length);
        numArray1 = numArray2;
      }
      return numArray1;
    }

    static CallerID __\u003CGetCallerID\u003E()
    {
      if (Kit.__\u003CcallerID\u003E == null)
        Kit.__\u003CcallerID\u003E = (CallerID) new Kit.__\u003CCallerID\u003E();
      return Kit.__\u003CcallerID\u003E;
    }

    [InnerClass]
    internal sealed class ComplexKey : Object
    {
      [Modifiers]
      private object key1;
      [Modifiers]
      private object key2;
      private int hash;

      [LineNumberTable(new byte[] {160, 150, 104, 103, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal ComplexKey([In] object obj0, [In] object obj1)
      {
        Kit.ComplexKey complexKey = this;
        this.key1 = obj0;
        this.key2 = obj1;
      }

      [LineNumberTable(new byte[] {160, 157, 104, 98, 103})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual bool equals([In] object obj0)
      {
        if (!(obj0 is Kit.ComplexKey))
          return false;
        Kit.ComplexKey complexKey = (Kit.ComplexKey) obj0;
        return Object.instancehelper_equals(this.key1, complexKey.key1) && Object.instancehelper_equals(this.key2, complexKey.key2);
      }

      [LineNumberTable(new byte[] {160, 165, 104, 157})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public virtual int hashCode()
      {
        if (this.hash == 0)
          this.hash = Object.instancehelper_hashCode(this.key1) ^ Object.instancehelper_hashCode(this.key2);
        return this.hash;
      }
    }

    private sealed class __\u003CCallerID\u003E : CallerID
    {
      internal __\u003CCallerID\u003E()
      {
      }
    }
  }
}
