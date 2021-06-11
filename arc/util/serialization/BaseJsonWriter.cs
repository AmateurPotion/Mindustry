// Decompiled with JetBrains decompiler
// Type: arc.util.serialization.BaseJsonWriter
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using IKVM.Attributes;
using java.io;
using java.lang;

namespace arc.util.serialization
{
  [Implements(new string[] {"java.io.Closeable"})]
  public interface BaseJsonWriter : Closeable, AutoCloseable
  {
    void setOutputType(JsonWriter.OutputType jwot);

    void setQuoteLongValues(bool b);

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter name(string str);

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter value(object obj);

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter @object();

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter pop();

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter array();

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter set(string str, object obj);

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter @object(string str);

    [Throws(new string[] {"java.io.IOException"})]
    BaseJsonWriter array(string str);
  }
}
