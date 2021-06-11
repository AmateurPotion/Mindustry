// Decompiled with JetBrains decompiler
// Type: arc.Settings
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.files;
using arc.func;
using arc.util;
using arc.util.io;
using arc.util.serialization;
using IKVM.Attributes;
using IKVM.Runtime;
using java.io;
using java.lang;
using java.text;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace arc
{
  public class Settings : Object
  {
    protected internal const byte typeBool = 0;
    protected internal const byte typeInt = 1;
    protected internal const byte typeLong = 2;
    protected internal const byte typeFloat = 3;
    protected internal const byte typeString = 4;
    protected internal const byte typeBinary = 5;
    protected internal Fi dataDirectory;
    protected internal string appName;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Object;>;")]
    protected internal ObjectMap defaults;
    [Signature("Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/Object;>;")]
    protected internal HashMap values;
    protected internal bool modified;
    [Signature("Larc/func/Cons<Ljava/lang/Throwable;>;")]
    protected internal Cons errorHandler;
    protected internal bool hasErrored;
    protected internal bool shouldAutosave;
    protected internal bool loaded;
    protected internal ByteArrayOutputStream byteStream;
    protected internal ReusableByteInStream byteInputStream;
    protected internal UBJsonReader ureader;
    protected internal Json json;

    [LineNumberTable(332)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(string name, string def) => (string) this.get(name, (object) def);

    [LineNumberTable(new byte[] {161, 8, 159, 17, 110, 137, 159, 27})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void put(string name, object @object)
    {
      switch (@object)
      {
        case Float _:
        case Integer _:
        case Boolean _:
        case Long _:
        case string _:
        case byte[] _:
          this.values.put((object) name, @object);
          this.modified = true;
          break;
        default:
          string str = new StringBuilder().append("Invalid object stored: ").append(@object != null ? (object) Object.instancehelper_getClass(@object) : (object) (Class) null).append(". Use putObject() for serialization.").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new IllegalArgumentException(str);
      }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setDataDirectory(Fi file) => this.dataDirectory = file;

    [LineNumberTable(320)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name, int def) => ((Integer) this.get(name, (object) Integer.valueOf(def))).intValue();

    [LineNumberTable(new byte[] {160, 137, 103, 57, 166})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void defaults(params object[] objects)
    {
      for (int index = 0; index < objects.Length; index += 2)
        this.defaults.put((object) (string) objects[index], objects[index + 1]);
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Class<*>;Ljava/lang/Object;)V")]
    [LineNumberTable(new byte[] {160, 168, 139, 118, 153, 146, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void putJson(string name, Class elementType, object value)
    {
      this.byteStream.reset();
      this.json.setWriter((BaseJsonWriter) new UBJsonWriter((OutputStream) this.byteStream));
      this.json.writeValue(value, value != null ? Object.instancehelper_getClass(value) : (Class) null, elementType);
      this.put(name, (object) this.byteStream.toByteArray());
      this.modified = true;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Ljava/lang/Class;Larc/func/Prov<TT;>;)TT;")]
    [LineNumberTable(new byte[] {160, 180, 115, 114, 127, 23, 97, 127, 38})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object getJson(string name, Class type, Class elementType, Prov def)
    {
      object obj;
      Exception exception;
      try
      {
        if (!this.has(name))
          return def.get();
        this.byteInputStream.setBytes(this.getBytes(name));
        obj = this.json.readValue(type, elementType, this.ureader.parse((InputStream) this.byteInputStream));
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_5;
      }
      return obj;
label_5:
      Exception e = exception;
      this.writeLog(new StringBuilder().append("Failed to write JSON key=").append(name).append(" type=").append((object) type).append(":\n").append(Strings.getStackTrace(e)).toString());
      return def.get();
    }

    [LineNumberTable(344)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBool(string name) => this.getBool(name, ((Boolean) this.defaults.get((object) name, (object) Boolean.valueOf(false))).booleanValue());

    [LineNumberTable(340)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual int getInt(string name) => this.getInt(name, ((Integer) this.defaults.get((object) name, (object) Integer.valueOf(0))).intValue());

    [LineNumberTable(238)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getDataDirectory() => this.dataDirectory == null ? Core.files.absolute(OS.getAppDataDirectoryString(this.appName)) : this.dataDirectory;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAppName(string name) => this.appName = name;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setJson(Json json) => this.json = json;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setAutosave(bool autosave) => this.shouldAutosave = autosave;

    [LineNumberTable(new byte[] {19, 102, 252, 73, 226, 56, 97, 127, 6, 104, 150, 135, 167, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void load()
    {
      Exception exception;
      try
      {
        this.loadValues();
        Core.keybinds.load();
        goto label_7;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception e = exception;
      this.writeLog(new StringBuilder().append("Error in load: ").append(Strings.getStackTrace(e)).toString());
      if (this.errorHandler == null)
        throw Throwable.__\u003Cunmap\u003E(e);
      if (!this.hasErrored)
        this.errorHandler.get((object) e);
      this.hasErrored = true;
label_7:
      this.loaded = true;
    }

    [LineNumberTable(367)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getString(string name) => this.getString(name, (string) this.defaults.get((object) name));

    [LineNumberTable(324)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBool(string name, bool def)
    {
      int num = def ? 1 : 0;
      return ((Boolean) this.get(name, (object) Boolean.valueOf(num != 0))).booleanValue();
    }

    [LineNumberTable(new byte[] {55, 104, 134})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void manualSave()
    {
      if (!this.loaded)
        return;
      this.forceSave();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool modified() => this.modified;

    [LineNumberTable(new byte[] {37, 137, 106, 248, 73, 226, 56, 97, 127, 27, 104, 150, 135, 135, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void forceSave()
    {
      if (!this.loaded)
        return;
      Exception exception;
      try
      {
        Core.keybinds.save();
        this.saveValues();
        goto label_9;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception e = exception;
      this.writeLog(new StringBuilder().append("Error in forceSave to ").append((object) this.getSettingsFile()).append(":\n").append(Strings.getStackTrace(e)).toString());
      if (this.errorHandler == null)
        throw Throwable.__\u003Cunmap\u003E(e);
      if (!this.hasErrored)
        this.errorHandler.get((object) e);
      this.hasErrored = true;
label_9:
      this.modified = false;
    }

    [Signature("(Larc/func/Cons<Ljava/lang/Throwable;>;)V")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void setErrorHandler(Cons handler) => this.errorHandler = handler;

    [LineNumberTable(new byte[] {161, 18, 109, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void remove(string name)
    {
      this.values.remove((object) name);
      this.modified = true;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Larc/func/Prov<TT;>;)TT;")]
    [LineNumberTable(304)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual object getJson(string name, Class type, Prov def) => this.getJson(name, type, (Class) null, def);

    [LineNumberTable(new byte[] {160, 164, 105})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void putJson(string name, object value) => this.putJson(name, (Class) null, value);

    [LineNumberTable(397)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual int keySize() => this.values.size();

    [LineNumberTable(363)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] getBytes(string name) => this.getBytes(name, (byte[]) this.defaults.get((object) name));

    [LineNumberTable(270)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object get(string name, object def) => this.values.containsKey((object) name) ? this.values.get((object) name) : def;

    [LineNumberTable(new byte[] {160, 235, 106, 102, 141})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void getBoolOnce(string name, Runnable run)
    {
      if (this.getBool(name, false))
        return;
      run.run();
      this.put(name, (object) Boolean.valueOf(true));
    }

    [LineNumberTable(266)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool has(string name) => this.values.containsKey((object) name);

    [LineNumberTable(229)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getSettingsFile() => this.getDataDirectory().child("settings.bin");

    [LineNumberTable(new byte[] {160, 144, 107})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void clear() => this.values.clear();

    [Signature("()Ljava/lang/Iterable<Ljava/lang/String;>;")]
    [LineNumberTable(393)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Iterable keys() => (Iterable) this.values.keySet();

    [Signature("(Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Object;>;)V")]
    [LineNumberTable(new byte[] {161, 1, 127, 1, 119, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void putAll(ObjectMap map)
    {
      ObjectMap.Entries entries = map.entries().iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        this.put((string) entry.key, entry.value);
      }
    }

    [LineNumberTable(new byte[] {62, 112, 102, 135})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void autosave()
    {
      if (!this.modified || !this.shouldAutosave)
        return;
      this.forceSave();
      this.modified = false;
    }

    [LineNumberTable(new byte[] {159, 159, 232, 69, 107, 107, 203, 103, 167, 109, 107, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public Settings()
    {
      Settings settings = this;
      this.appName = "app";
      this.defaults = new ObjectMap();
      this.values = new HashMap();
      this.shouldAutosave = true;
      this.loaded = false;
      this.byteStream = new ByteArrayOutputStream(32);
      this.byteInputStream = new ReusableByteInStream();
      this.ureader = new UBJsonReader();
      this.json = new Json();
    }

    [LineNumberTable(new byte[] {71, 122, 127, 37, 193, 108, 191, 21, 113, 255, 81, 79, 229, 50, 97, 107, 191, 27, 140, 113, 106, 223, 29, 226, 61, 97, 127, 27, 171})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void loadValues()
    {
      if (!this.getSettingsFile().exists())
      {
        if (!this.getBackupSettingsFile().exists())
        {
          this.writeLog(new StringBuilder().append("No settings files found: ").append(this.getSettingsFile().absolutePath()).append(" and ").append(this.getBackupSettingsFile().absolutePath()).toString());
          return;
        }
      }
      Exception exception1;
      try
      {
        this.loadValues(this.getSettingsFile());
        this.writeLog(new StringBuilder().append("Loaded ").append(this.values.size()).append(" values").toString());
        this.getSettingsFile().copyTo(this.getBackupSettingsFile());
        this.writeLog(new StringBuilder().append("Backed up ").append((object) this.getSettingsFile()).append(" to ").append((object) this.getBackupSettingsFile()).append(" (").append(this.getSettingsFile().length()).append(" bytes)").toString());
        return;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Log.err("Failed to load base settings file, attempting to load backup.", exception2);
      this.writeLog(new StringBuilder().append("Failed to load base file ").append((object) this.getSettingsFile()).append(":\n").append(Strings.getStackTrace(exception2)).toString());
      Exception exception3;
      try
      {
        this.loadValues(this.getBackupSettingsFile());
        this.getBackupSettingsFile().copyTo(this.getSettingsFile());
        Log.info((object) "Loaded backup settings file.");
        this.writeLog(new StringBuilder().append("Loaded backup settings file after load failure. Length: ").append(this.getBackupSettingsFile().length()).toString());
        return;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      this.writeLog(new StringBuilder().append("Failed to load backup file ").append((object) this.getSettingsFile()).append(":\n").append(Strings.getStackTrace(exception4)).toString());
      Log.err("Failed to load backup settings file.", exception4);
    }

    [LineNumberTable(new byte[] {161, 33, 113, 191, 75, 2, 97, 139})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void writeLog([In] string obj0)
    {
      Exception th;
      try
      {
        Fi fi = this.getDataDirectory().child("settings.log");
        StringBuilder stringBuilder = new StringBuilder().append("[");
        SimpleDateFormat.__\u003Cclinit\u003E();
        string str = ((DateFormat) new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.getDefault())).format(new Date());
        string @string = stringBuilder.append(str).append("] ").append(obj0).append("\n").toString();
        fi.writeString(@string, true);
        return;
      }
      catch (Exception ex)
      {
        th = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Log.err("Failed to write settings log", th);
    }

    [LineNumberTable(new byte[] {160, 72, 135, 114, 145, 127, 9, 145, 136, 105, 103, 119, 105, 103, 119, 105, 103, 119, 105, 103, 117, 105, 103, 111, 105, 103, 110, 141, 147, 255, 9, 34, 255, 74, 98, 226, 60, 130, 103, 191, 8, 127, 42})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void saveValues()
    {
      Fi settingsFile = this.getSettingsFile();
      DataOutputStream dataOutputStream;
      Exception exception1;
      Exception exception2;
      try
      {
        dataOutputStream = new DataOutputStream(settingsFile.write(false, 8192));
        try
        {
          dataOutputStream.writeInt(this.values.size());
          Iterator iterator = this.values.entrySet().iterator();
          while (iterator.hasNext())
          {
            Map.Entry entry = (Map.Entry) iterator.next();
            dataOutputStream.writeUTF((string) entry.getKey());
            object obj = entry.getValue();
            switch (obj)
            {
              case Boolean _:
                dataOutputStream.writeByte(0);
                dataOutputStream.writeBoolean(((Boolean) obj).booleanValue());
                continue;
              case Integer _:
                dataOutputStream.writeByte(1);
                dataOutputStream.writeInt(((Integer) obj).intValue());
                continue;
              case Long _:
                dataOutputStream.writeByte(2);
                dataOutputStream.writeLong(((Long) obj).longValue());
                continue;
              case Float _:
                dataOutputStream.writeByte(3);
                dataOutputStream.writeFloat(((Float) obj).floatValue());
                continue;
              case string _:
                dataOutputStream.writeByte(4);
                dataOutputStream.writeUTF((string) obj);
                continue;
              case byte[] _:
                dataOutputStream.writeByte(5);
                dataOutputStream.writeInt(((byte[]) obj).Length);
                ((FilterOutputStream) dataOutputStream).write((byte[]) obj);
                continue;
              default:
                continue;
            }
          }
        }
        catch (Exception ex)
        {
          exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
          goto label_14;
        }
        ((FilterOutputStream) dataOutputStream).close();
        goto label_29;
      }
      catch (Exception ex)
      {
        exception2 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_15;
      }
label_14:
      Exception exception3 = exception1;
      Exception exception4;
      Exception exception5;
      Exception exception6;
      try
      {
        exception4 = exception3;
        try
        {
          ((FilterOutputStream) dataOutputStream).close();
          goto label_25;
        }
        catch (Exception ex)
        {
          exception5 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        }
      }
      catch (Exception ex)
      {
        exception6 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_21;
      }
      Exception exception7 = exception5;
      Exception exception8;
      try
      {
        Exception exception9 = exception7;
        Throwable.instancehelper_addSuppressed(exception4, exception9);
        goto label_25;
      }
      catch (Exception ex)
      {
        exception8 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception10 = exception8;
      goto label_28;
label_21:
      exception10 = exception6;
      goto label_28;
label_25:
      Exception exception11;
      try
      {
        throw Throwable.__\u003Cunmap\u003E(exception4);
      }
      catch (Exception ex)
      {
        exception11 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      exception10 = exception11;
      goto label_28;
label_15:
      exception10 = exception2;
label_28:
      Exception exception12 = exception10;
      settingsFile.delete();
      string str = new StringBuilder().append("Error writing preferences: ").append((object) settingsFile).toString();
      Exception exception13 = exception12;
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new RuntimeException(str, exception13);
label_29:
      this.writeLog(new StringBuilder().append("Saving ").append(this.values.size()).append(" values; ").append(settingsFile.length()).append(" bytes").toString());
    }

    [LineNumberTable(233)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Fi getBackupSettingsFile() => this.getDataDirectory().child("settings_backup.bin");

    [Throws(new string[] {"java.io.IOException"})]
    [LineNumberTable(new byte[] {101, 113, 103, 105, 103, 137, 159, 5, 120, 133, 120, 133, 120, 133, 121, 130, 115, 130, 104, 105, 105, 239, 40, 251, 92, 232, 34, 255, 18, 95})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void loadValues(Fi file)
    {
      DataInputStream dataInputStream = new DataInputStream((InputStream) file.read(8192));
      Exception exception1;
      try
      {
        int num = dataInputStream.readInt();
        for (int index = 0; index < num; ++index)
        {
          string str = dataInputStream.readUTF();
          switch ((sbyte) dataInputStream.readByte())
          {
            case 0:
              this.values.put((object) str, (object) Boolean.valueOf(dataInputStream.readBoolean()));
              break;
            case 1:
              this.values.put((object) str, (object) Integer.valueOf(dataInputStream.readInt()));
              break;
            case 2:
              this.values.put((object) str, (object) Long.valueOf(dataInputStream.readLong()));
              break;
            case 3:
              this.values.put((object) str, (object) Float.valueOf(dataInputStream.readFloat()));
              break;
            case 4:
              this.values.put((object) str, (object) dataInputStream.readUTF());
              break;
            case 5:
              byte[] numArray = new byte[dataInputStream.readInt()];
              dataInputStream.read(numArray);
              this.values.put((object) str, (object) numArray);
              break;
          }
        }
        goto label_13;
      }
      catch (Exception ex)
      {
        exception1 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception2 = exception1;
      Exception exception3;
      try
      {
        ((FilterInputStream) dataInputStream).close();
        goto label_17;
      }
      catch (Exception ex)
      {
        exception3 = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception exception4 = exception3;
      Throwable.instancehelper_addSuppressed(exception2, exception4);
label_17:
      throw Throwable.__\u003Cunmap\u003E(exception2);
label_13:
      ((FilterInputStream) dataInputStream).close();
    }

    [LineNumberTable(312)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual long getLong(string name, long def) => ((Long) this.get(name, (object) Long.valueOf(def))).longValue();

    [LineNumberTable(308)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name, float def) => ((Float) this.get(name, (object) Float.valueOf(def))).floatValue();

    [LineNumberTable(328)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual byte[] getBytes(string name, byte[] def) => (byte[]) this.get(name, (object) def);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual string getAppName() => this.appName;

    [LineNumberTable(262)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object getDefault(string name) => this.defaults.get((object) name);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool isModified() => this.modified;

    [LineNumberTable(316)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Long getLong(string name) => Long.valueOf(this.getLong(name, 0L));

    [LineNumberTable(336)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual float getFloat(string name) => this.getFloat(name, ((Float) this.defaults.get((object) name, (object) Float.valueOf(0.0f))).floatValue());

    [LineNumberTable(new byte[] {160, 243, 105, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool getBoolOnce(string name)
    {
      int num = this.getBool(name, false) ? 1 : 0;
      this.put(name, (object) Boolean.valueOf(true));
      return num != 0;
    }
  }
}
