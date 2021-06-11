// Decompiled with JetBrains decompiler
// Type: arc.assets.AssetManager
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc.@struct;
using arc.assets.loaders;
using arc.assets.loaders.resolvers;
using arc.audio;
using arc.files;
using arc.graphics;
using arc.graphics.g2d;
using arc.graphics.gl;
using arc.util;
using arc.util.async;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using java.util;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace arc.assets
{
  public class AssetManager : Object, Disposable
  {
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Larc/struct/ObjectMap<Ljava/lang/String;Larc/assets/RefCountedContainer;>;>;")]
    internal ObjectMap assets;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Ljava/lang/Class;>;")]
    internal ObjectMap assetTypes;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/String;Larc/struct/Seq<Ljava/lang/String;>;>;")]
    internal ObjectMap assetDependencies;
    [Modifiers]
    [Signature("Larc/struct/ObjectSet<Ljava/lang/String;>;")]
    internal ObjectSet injected;
    [Modifiers]
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class;Larc/struct/ObjectMap<Ljava/lang/String;Larc/assets/loaders/AssetLoader;>;>;")]
    internal ObjectMap loaders;
    [Modifiers]
    [Signature("Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
    internal Seq loadQueue;
    [Modifiers]
    internal AsyncExecutor executor;
    [Modifiers]
    [Signature("Ljava/util/Stack<Larc/assets/AssetLoadingTask;>;")]
    internal Stack tasks;
    [Modifiers]
    internal FileHandleResolver resolver;
    internal AssetErrorListener listener;
    internal int loaded;
    internal int toLoad;
    internal int peakTasks;

    [LineNumberTable(new byte[] {159, 182, 107})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetManager()
      : this((FileHandleResolver) new InternalFileHandleResolver())
    {
    }

    [Signature("<T:Ljava/lang/Object;P:Larc/assets/AssetLoaderParameters<TT;>;>(Ljava/lang/Class<TT;>;Ljava/lang/String;Larc/assets/loaders/AssetLoader<TT;TP;>;)V")]
    [LineNumberTable(new byte[] {162, 65, 115, 115, 114, 119, 115})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void setLoader(Class type, string suffix, AssetLoader loader)
    {
      if (type == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("type cannot be null.");
      }
      if (loader == null)
      {
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new IllegalArgumentException("loader cannot be null.");
      }
      ObjectMap objectMap = (ObjectMap) this.loaders.get((object) type);
      if (objectMap == null)
        this.loaders.put((object) type, (object) (objectMap = new ObjectMap()));
      objectMap.put(suffix != null ? (object) suffix : (object) "", (object) loader);
    }

    [Signature("<T:Ljava/lang/Object;P:Larc/assets/AssetLoaderParameters<TT;>;>(Ljava/lang/Class<TT;>;Larc/assets/loaders/AssetLoader<TT;TP;>;)V")]
    [LineNumberTable(new byte[] {162, 54, 105})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void setLoader(Class type, AssetLoader loader) => this.setLoader(type, (string) null, loader);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;)Larc/assets/AssetDescriptor;")]
    [LineNumberTable(311)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor load(string fileName, Class type) => this.load(fileName, type, (AssetLoaderParameters) null);

    [LineNumberTable(new byte[] {160, 235, 110, 248, 82})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor load(Loadable load)
    {
      if (this.getLoader(Object.instancehelper_getClass((object) load)) == null)
        this.setLoader(Object.instancehelper_getClass((object) load), (AssetLoader) new AssetManager.\u0032(this, (FileHandleResolver) new InternalFileHandleResolver(), load));
      return this.load(load.getName(), Object.instancehelper_getClass((object) load), (AssetLoaderParameters) null);
    }

    [LineNumberTable(423)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor load(AssetDescriptor desc) => this.load(desc.__\u003C\u003EfileName, desc.__\u003C\u003Etype, desc.__\u003C\u003Eparams);

    [Signature("(Ljava/lang/String;Ljava/lang/Class<*>;Ljava/lang/Runnable;)Larc/assets/AssetDescriptor;")]
    [LineNumberTable(318)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor loadRun(
      string name,
      Class type,
      Runnable loadasync)
    {
      return this.loadRun(name, type, loadasync, (Runnable) new AssetManager.__\u003C\u003EAnon0());
    }

    [Signature("(Ljava/lang/String;Ljava/lang/Class<*>;Ljava/lang/Runnable;Ljava/lang/Runnable;)Larc/assets/AssetDescriptor;")]
    [LineNumberTable(new byte[] {160, 211, 105, 242, 77, 159, 6})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor loadRun(
      string name,
      Class type,
      Runnable loadasync,
      Runnable loadsync)
    {
      if (this.getLoader(type) == null)
      {
        this.setLoader(type, (AssetLoader) new AssetManager.\u0031(this, loadasync, loadsync));
        return this.load(name, type, (AssetLoaderParameters) null);
      }
      string str = new StringBuilder().append("Class already registered or loaded: ").append((object) type).toString();
      Throwable.__\u003CsuppressFillInStackTrace\u003E();
      throw new IllegalArgumentException(str);
    }

    [LineNumberTable(new byte[] {161, 93, 137, 103, 109, 101})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual bool update(int millis)
    {
      long num1 = Time.millis() + (long) millis;
      int num2;
      while (true)
      {
        num2 = this.update() ? 1 : 0;
        if (num2 == 0 && Time.millis() <= num1)
          Threads.yield();
        else
          break;
      }
      return num2 != 0;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Larc/struct/Seq<TT;>;)Larc/struct/Seq<TT;>;")]
    [LineNumberTable(new byte[] {63, 114, 99, 127, 1, 119, 130})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Seq getAll(Class type, Seq @out)
    {
      ObjectMap objectMap = (ObjectMap) this.assets.get((object) type);
      if (objectMap != null)
      {
        ObjectMap.Entries entries = objectMap.entries().iterator();
        while (((Iterator) entries).hasNext())
        {
          ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
          @out.add(((RefCountedContainer) entry.value).getObject(type));
        }
      }
      return @out;
    }

    [Signature("<T:Ljava/lang/Object;>(TT;)Ljava/lang/String;")]
    [LineNumberTable(new byte[] {160, 121, 127, 9, 114, 127, 2, 121, 119, 98, 101})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual string getAssetFileName(object asset)
    {
      ObjectMap.Keys keys1 = this.assets.keys().iterator();
label_1:
      while (((Iterator) keys1).hasNext())
      {
        ObjectMap objectMap = (ObjectMap) this.assets.get((object) (Class) ((Iterator) keys1).next());
        ObjectMap.Keys keys2 = objectMap.keys().iterator();
        string str;
        object objA;
        do
        {
          if (((Iterator) keys2).hasNext())
          {
            str = (string) ((Iterator) keys2).next();
            objA = ((RefCountedContainer) objectMap.get((object) str)).getObject((Class) ClassLiteral<Object>.Value);
          }
          else
            goto label_1;
        }
        while (!object.ReferenceEquals(objA, asset) && !Object.instancehelper_equals(asset, objA));
        return str;
      }
      return (string) null;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;)TT;")]
    [LineNumberTable(new byte[] {49, 114, 127, 9, 109, 127, 9, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object get(string fileName, Class type)
    {
      ObjectMap objectMap = (ObjectMap) this.assets.get((object) type);
      if (objectMap == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      RefCountedContainer countedContainer = (RefCountedContainer) objectMap.get((object) fileName);
      if (countedContainer == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      object obj = countedContainer.getObject(type);
      if (obj == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return obj;
    }

    [LineNumberTable(new byte[] {161, 62, 141, 122, 168, 145, 127, 31, 97, 103})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool update()
    {
      int num;
      Exception exception;
      try
      {
        if (((Vector) this.tasks).size() == 0)
        {
          while (this.loadQueue.size != 0 && ((Vector) this.tasks).size() == 0)
            this.nextTask();
          if (((Vector) this.tasks).size() == 0)
            return true;
        }
        num = !this.updateTask() || this.loadQueue.size != 0 || ((Vector) this.tasks).size() != 0 ? 0 : 1;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
        goto label_8;
      }
      return num != 0;
label_8:
      this.handleTaskError(exception);
      return this.loadQueue.size == 0;
    }

    [LineNumberTable(new byte[] {160, 144, 101})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool isLoaded(string fileName) => fileName != null && this.assetTypes.containsKey((object) fileName);

    [LineNumberTable(new byte[] {112, 110, 113, 115, 110, 225, 69, 98, 112, 126, 98, 226, 61, 230, 70, 100, 110, 109, 193, 114, 159, 9, 190, 103, 170, 115, 182, 109, 216, 115, 100, 127, 1, 114, 162, 106, 141})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void unload(string fileName)
    {
      if (((Vector) this.tasks).size() > 0)
      {
        AssetLoadingTask assetLoadingTask = (AssetLoadingTask) ((Vector) this.tasks).firstElement();
        if (String.instancehelper_equals(assetLoadingTask.assetDesc.__\u003C\u003EfileName, (object) fileName))
        {
          assetLoadingTask.cancel = true;
          Thread.MemoryBarrier();
          return;
        }
      }
      int index1 = -1;
      for (int index2 = 0; index2 < this.loadQueue.size; ++index2)
      {
        if (String.instancehelper_equals(((AssetDescriptor) this.loadQueue.get(index2)).__\u003C\u003EfileName, (object) fileName))
        {
          index1 = index2;
          break;
        }
      }
      if (index1 != -1)
      {
        --this.toLoad;
        this.loadQueue.remove(index1);
      }
      else
      {
        Class @class = (Class) this.assetTypes.get((object) fileName);
        if (@class == null)
        {
          string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
        RefCountedContainer countedContainer = (RefCountedContainer) ((ObjectMap) this.assets.get((object) @class)).get((object) fileName);
        countedContainer.decRefCount();
        if (countedContainer.getRefCount() <= 0)
        {
          if (countedContainer.getObject((Class) ClassLiteral<Object>.Value) is Disposable)
            ((Disposable) countedContainer.getObject((Class) ClassLiteral<Object>.Value)).dispose();
          this.assetTypes.remove((object) fileName);
          ((ObjectMap) this.assets.get((object) @class)).remove((object) fileName);
        }
        Seq seq = (Seq) this.assetDependencies.get((object) fileName);
        if (seq != null)
        {
          Iterator iterator = seq.iterator();
          while (iterator.hasNext())
          {
            string fileName1 = (string) iterator.next();
            if (this.isLoaded(fileName1))
              this.unload(fileName1);
          }
        }
        if (countedContainer.getRefCount() > 0)
          return;
        this.assetDependencies.remove((object) fileName);
      }
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;)TT;")]
    [LineNumberTable(new byte[] {32, 114, 127, 9, 114, 127, 9, 109, 127, 9, 104, 127, 9})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object get(string fileName)
    {
      Class type = (Class) this.assetTypes.get((object) fileName);
      if (type == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      ObjectMap objectMap = (ObjectMap) this.assets.get((object) type);
      if (objectMap == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      RefCountedContainer countedContainer = (RefCountedContainer) objectMap.get((object) fileName);
      if (countedContainer == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      object obj = countedContainer.getObject(type);
      if (obj == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return obj;
    }

    [LineNumberTable(700)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual int getLoadedAssets() => this.assetTypes.size;

    [Signature("()Larc/struct/Seq<Ljava/lang/String;>;")]
    [LineNumberTable(825)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Seq getAssetNames() => this.assetTypes.keys().toSeq();

    [LineNumberTable(835)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Class getAssetType(string fileName) => (Class) this.assetTypes.get((object) fileName);

    [LineNumberTable(new byte[] {162, 84, 110, 104, 105, 159, 1})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual float getProgress()
    {
      if (this.toLoad == 0)
        return 1f;
      float loaded = (float) this.loaded;
      if (this.peakTasks > 0)
        loaded += (float) (this.peakTasks - ((Vector) this.tasks).size()) / (float) this.peakTasks;
      return Math.min(1f, loaded / (float) this.toLoad);
    }

    [LineNumberTable(new byte[] {161, 80, 110, 150})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor getCurrentLoading() => ((Vector) this.tasks).size() > 0 ? ((AssetLoadingTask) ((Vector) this.tasks).firstElement()).assetDesc : (AssetDescriptor) null;

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;)Larc/assets/loaders/AssetLoader;")]
    [LineNumberTable(280)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AssetLoader getLoader(Class type) => this.getLoader(type, (string) null);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;Larc/assets/AssetLoaderParameters<TT;>;)Larc/assets/AssetDescriptor;")]
    [LineNumberTable(new byte[] {161, 8, 105, 191, 14, 109, 103, 103, 231, 70, 115, 114, 159, 29, 255, 31, 60, 233, 72, 115, 119, 159, 29, 255, 31, 60, 233, 72, 114, 108, 127, 1, 159, 26, 110, 105, 108})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual AssetDescriptor load(
      string fileName,
      Class type,
      AssetLoaderParameters parameter)
    {
      if (this.getLoader(type, fileName) == null)
      {
        string message = new StringBuilder().append("No loader for type: ").append(type.getSimpleName()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      if (this.loadQueue.size == 0)
      {
        this.loaded = 0;
        this.toLoad = 0;
        this.peakTasks = 0;
      }
      for (int index = 0; index < this.loadQueue.size; ++index)
      {
        AssetDescriptor assetDescriptor = (AssetDescriptor) this.loadQueue.get(index);
        if (String.instancehelper_equals(assetDescriptor.__\u003C\u003EfileName, (object) fileName) && !Object.instancehelper_equals((object) assetDescriptor.__\u003C\u003Etype, (object) type))
        {
          string message = new StringBuilder().append("Asset with name '").append(fileName).append("' already in preload queue, but has different type (expected: ").append(type.getSimpleName()).append(", found: ").append(assetDescriptor.__\u003C\u003Etype.getSimpleName()).append(")").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
      }
      for (int index = 0; index < ((Vector) this.tasks).size(); ++index)
      {
        AssetDescriptor assetDesc = ((AssetLoadingTask) ((Vector) this.tasks).get(index)).assetDesc;
        if (String.instancehelper_equals(assetDesc.__\u003C\u003EfileName, (object) fileName) && !Object.instancehelper_equals((object) assetDesc.__\u003C\u003Etype, (object) type))
        {
          string message = new StringBuilder().append("Asset with name '").append(fileName).append("' already in task list, but has different type (expected: ").append(type.getSimpleName()).append(", found: ").append(assetDesc.__\u003C\u003Etype.getSimpleName()).append(")").toString();
          Throwable.__\u003CsuppressFillInStackTrace\u003E();
          throw new ArcRuntimeException(message);
        }
      }
      Class @class = (Class) this.assetTypes.get((object) fileName);
      if (@class != null && !Object.instancehelper_equals((object) @class, (object) type))
      {
        string message = new StringBuilder().append("Asset with name '").append(fileName).append("' already loaded, but has different type (expected: ").append(type.getSimpleName()).append(", found: ").append(@class.getSimpleName()).append(")").toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      ++this.toLoad;
      AssetDescriptor assetDescriptor1 = new AssetDescriptor(fileName, type, parameter);
      this.loadQueue.add((object) assetDescriptor1);
      return assetDescriptor1;
    }

    [Signature("(Ljava/lang/String;Larc/struct/Seq<Larc/assets/AssetDescriptor;>;)V")]
    [LineNumberTable(new byte[] {161, 132, 103, 123, 112, 109, 104, 98, 102})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    internal virtual void injectDependencies([In] string obj0, [In] Seq obj1)
    {
      ObjectSet injected = this.injected;
      Iterator iterator = obj1.iterator();
      while (iterator.hasNext())
      {
        AssetDescriptor assetDescriptor = (AssetDescriptor) iterator.next();
        if (!injected.contains((object) assetDescriptor.__\u003C\u003EfileName))
        {
          injected.add((object) assetDescriptor.__\u003C\u003EfileName);
          this.injectDependency(obj0, assetDescriptor);
        }
      }
      injected.clear();
    }

    [LineNumberTable(new byte[] {159, 187, 104})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetManager(FileHandleResolver resolver)
      : this(resolver, true)
    {
    }

    [LineNumberTable(new byte[] {159, 129, 98, 232, 33, 107, 107, 107, 139, 107, 171, 139, 103, 103, 103, 231, 82, 103, 102, 113, 113, 113, 113, 113, 113, 113, 113, 145, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public AssetManager(FileHandleResolver resolver, bool defaultLoaders)
    {
      int num = defaultLoaders ? 1 : 0;
      // ISSUE: explicit constructor call
      base.\u002Ector();
      AssetManager assetManager = this;
      this.assets = new ObjectMap();
      this.assetTypes = new ObjectMap();
      this.assetDependencies = new ObjectMap();
      this.injected = new ObjectSet();
      this.loaders = new ObjectMap();
      this.loadQueue = new Seq();
      this.tasks = new Stack();
      this.listener = (AssetErrorListener) null;
      this.loaded = 0;
      this.toLoad = 0;
      this.peakTasks = 0;
      this.resolver = resolver;
      if (num != 0)
      {
        this.setLoader((Class) ClassLiteral<Font>.Value, (AssetLoader) new FontLoader(resolver));
        this.setLoader((Class) ClassLiteral<Music>.Value, (AssetLoader) new MusicLoader(resolver));
        this.setLoader((Class) ClassLiteral<Pixmap>.Value, (AssetLoader) new PixmapLoader(resolver));
        this.setLoader((Class) ClassLiteral<Sound>.Value, (AssetLoader) new SoundLoader(resolver));
        this.setLoader((Class) ClassLiteral<TextureAtlas>.Value, (AssetLoader) new TextureAtlasLoader(resolver));
        this.setLoader((Class) ClassLiteral<Texture>.Value, (AssetLoader) new TextureLoader(resolver));
        this.setLoader((Class) ClassLiteral<I18NBundle>.Value, (AssetLoader) new I18NBundleLoader(resolver));
        this.setLoader((Class) ClassLiteral<Shader>.Value, (AssetLoader) new ShaderProgramLoader(resolver));
        this.setLoader((Class) ClassLiteral<Cubemap>.Value, (AssetLoader) new CubemapLoader(resolver));
      }
      this.executor = new AsyncExecutor(1);
    }

    [LineNumberTable(new byte[] {160, 153, 114, 101, 109, 101})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool isLoaded(string fileName, Class type)
    {
      ObjectMap objectMap = (ObjectMap) this.assets.get((object) type);
      if (objectMap == null)
        return false;
      RefCountedContainer countedContainer = (RefCountedContainer) objectMap.get((object) fileName);
      return countedContainer != null && countedContainer.getObject(type) != null;
    }

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/Class<TT;>;Ljava/lang/String;)Larc/assets/loaders/AssetLoader;")]
    [LineNumberTable(new byte[] {160, 177, 114, 110, 116, 98, 98, 127, 2, 127, 9, 109, 146, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual AssetLoader getLoader(Class type, string fileName)
    {
      ObjectMap objectMap = (ObjectMap) this.loaders.get((object) type);
      if (objectMap == null || objectMap.size < 1)
        return (AssetLoader) null;
      if (fileName == null)
        return (AssetLoader) objectMap.get((object) "");
      AssetLoader assetLoader = (AssetLoader) null;
      int num = -1;
      ObjectMap.Entries entries = objectMap.entries().iterator();
      while (((Iterator) entries).hasNext())
      {
        ObjectMap.Entry entry = (ObjectMap.Entry) ((Iterator) entries).next();
        if (String.instancehelper_length((string) entry.key) > num && String.instancehelper_endsWith(fileName, (string) entry.key))
        {
          assetLoader = (AssetLoader) entry.value;
          num = String.instancehelper_length((string) entry.key);
        }
      }
      return assetLoader;
    }

    [LineNumberTable(new byte[] {161, 168, 210, 113, 119, 127, 3, 102, 108, 117, 157, 110, 130, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void nextTask()
    {
      AssetDescriptor assetDescriptor = (AssetDescriptor) this.loadQueue.remove(0);
      if (this.isLoaded(assetDescriptor.__\u003C\u003EfileName))
      {
        ((RefCountedContainer) ((ObjectMap) this.assets.get((object) (Class) this.assetTypes.get((object) assetDescriptor.__\u003C\u003EfileName))).get((object) assetDescriptor.__\u003C\u003EfileName)).incRefCount();
        this.incrementRefCountedDependencies(assetDescriptor.__\u003C\u003EfileName);
        if (assetDescriptor.__\u003C\u003Eparams != null && assetDescriptor.__\u003C\u003Eparams.loadedCallback != null)
          assetDescriptor.__\u003C\u003Eparams.loadedCallback.finishedLoading(this, assetDescriptor.__\u003C\u003EfileName, assetDescriptor.__\u003C\u003Etype);
        ++this.loaded;
      }
      else
        this.addTask(assetDescriptor);
    }

    [LineNumberTable(new byte[] {161, 217, 145, 130, 223, 15, 226, 61, 97, 110, 205, 134, 110, 110, 135, 140, 140, 191, 3, 127, 0, 191, 13, 150, 130})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private bool updateTask()
    {
      AssetLoadingTask assetLoadingTask = (AssetLoadingTask) this.tasks.peek();
      int num = 1;
      RuntimeException runtimeException;
      try
      {
        num = assetLoadingTask.cancel || assetLoadingTask.update() ? 1 : 0;
        goto label_6;
      }
      catch (Exception ex)
      {
        M0 m0 = ByteCodeHelper.MapException<RuntimeException>(ex, (ByteCodeHelper.MapFlags) 0);
        if (m0 == null)
          throw;
        else
          runtimeException = (RuntimeException) m0;
      }
      RuntimeException ex1 = runtimeException;
      assetLoadingTask.cancel = true;
      Thread.MemoryBarrier();
      this.taskFailed(assetLoadingTask.assetDesc, ex1);
label_6:
      if (num == 0)
        return false;
      if (((Vector) this.tasks).size() == 1)
      {
        ++this.loaded;
        this.peakTasks = 0;
      }
      this.tasks.pop();
      if (assetLoadingTask.cancel)
        return true;
      this.addAsset(assetLoadingTask.assetDesc.__\u003C\u003EfileName, assetLoadingTask.assetDesc.__\u003C\u003Etype, assetLoadingTask.getAsset());
      if (assetLoadingTask.assetDesc.__\u003C\u003Eparams != null && assetLoadingTask.assetDesc.__\u003C\u003Eparams.loadedCallback != null)
        assetLoadingTask.assetDesc.__\u003C\u003Eparams.loadedCallback.finishedLoading(this, assetLoadingTask.assetDesc.__\u003C\u003EfileName, assetLoadingTask.assetDesc.__\u003C\u003Etype);
      assetLoadingTask.assetDesc.loaded.get(assetLoadingTask.getAsset());
      return true;
    }

    [LineNumberTable(new byte[] {162, 20, 185, 113, 167, 116, 127, 3, 108, 194, 171, 104, 173, 104, 142, 140})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void handleTaskError([In] Exception obj0)
    {
      if (((Vector) this.tasks).isEmpty())
      {
        Exception t = obj0;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(t);
      }
      AssetLoadingTask assetLoadingTask = (AssetLoadingTask) this.tasks.pop();
      AssetDescriptor assetDesc = assetLoadingTask.assetDesc;
      if (assetLoadingTask.dependenciesLoaded && assetLoadingTask.dependencies != null)
      {
        Iterator iterator = assetLoadingTask.dependencies.iterator();
        while (iterator.hasNext())
          this.unload(((AssetDescriptor) iterator.next()).__\u003C\u003EfileName);
      }
      ((Vector) this.tasks).clear();
      if (this.listener != null)
        this.listener.error(assetDesc, obj0);
      if (assetDesc.errored != null)
      {
        assetDesc.errored.get((object) obj0);
      }
      else
      {
        Exception t = obj0;
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(t);
      }
    }

    [LineNumberTable(new byte[] {161, 125, 105, 103, 135})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finishLoadingAsset(string fileName)
    {
      while (!this.isLoaded(fileName))
      {
        this.update();
        Threads.yield();
      }
    }

    [LineNumberTable(new byte[] {161, 143, 114, 99, 102, 142, 172, 110, 119, 127, 3, 102, 108, 162, 135})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    private void injectDependency([In] string obj0, [In] AssetDescriptor obj1)
    {
      Seq seq = (Seq) this.assetDependencies.get((object) obj0);
      if (seq == null)
      {
        seq = new Seq();
        this.assetDependencies.put((object) obj0, (object) seq);
      }
      seq.add((object) obj1.__\u003C\u003EfileName);
      if (this.isLoaded(obj1.__\u003C\u003EfileName))
      {
        ((RefCountedContainer) ((ObjectMap) this.assets.get((object) (Class) this.assetTypes.get((object) obj1.__\u003C\u003EfileName))).get((object) obj1.__\u003C\u003EfileName)).incRefCount();
        this.incrementRefCountedDependencies(obj1.__\u003C\u003EfileName);
      }
      else
        this.addTask(obj1);
    }

    [LineNumberTable(new byte[] {162, 5, 114, 132, 123, 114, 126, 103, 103, 98})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void incrementRefCountedDependencies([In] string obj0)
    {
      Seq seq = (Seq) this.assetDependencies.get((object) obj0);
      if (seq == null)
        return;
      Iterator iterator = seq.iterator();
      while (iterator.hasNext())
      {
        string str = (string) iterator.next();
        ((RefCountedContainer) ((ObjectMap) this.assets.get((object) (Class) this.assetTypes.get((object) str))).get((object) str)).incRefCount();
        this.incrementRefCountedDependencies(str);
      }
    }

    [LineNumberTable(new byte[] {161, 191, 115, 99, 127, 16, 122, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void addTask([In] AssetDescriptor obj0)
    {
      AssetLoader loader = this.getLoader(obj0.__\u003C\u003Etype, obj0.__\u003C\u003EfileName);
      if (loader == null)
      {
        string message = new StringBuilder().append("No loader for type: ").append(obj0.__\u003C\u003Etype.getSimpleName()).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      this.tasks.push((object) new AssetLoadingTask(this, obj0, loader, this.executor));
      ++this.peakTasks;
    }

    [LineNumberTable(627)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void taskFailed(AssetDescriptor assetDesc, RuntimeException ex) => throw Throwable.__\u003Cunmap\u003E((Exception) ex);

    [Signature("<T:Ljava/lang/Object;>(Ljava/lang/String;Ljava/lang/Class<TT;>;TT;)V")]
    [LineNumberTable(new byte[] {161, 201, 174, 114, 99, 102, 142, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected internal virtual void addAsset(string fileName, Class type, object asset)
    {
      this.assetTypes.put((object) fileName, (object) type);
      ObjectMap objectMap = (ObjectMap) this.assets.get((object) type);
      if (objectMap == null)
      {
        objectMap = new ObjectMap();
        this.assets.put((object) type, (object) objectMap);
      }
      objectMap.put((object) fileName, (object) new RefCountedContainer(asset));
    }

    [LineNumberTable(new byte[] {162, 109, 108, 104, 130, 102, 145, 102, 113, 123, 104, 130, 126, 115, 102, 127, 1, 107, 102, 106, 98, 165, 123, 106, 135, 98, 133, 107, 107, 107, 103, 103, 103, 108, 107})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void clear()
    {
      this.loadQueue.clear();
      do
        ;
      while (!this.update());
      ObjectIntMap objectIntMap = new ObjectIntMap();
label_3:
      while (this.assetTypes.size > 0)
      {
        objectIntMap.clear();
        Seq seq1 = this.assetTypes.keys().toSeq();
        Iterator iterator1 = seq1.iterator();
        while (iterator1.hasNext())
        {
          string str = (string) iterator1.next();
          objectIntMap.put((object) str, 0);
        }
        Iterator iterator2 = seq1.iterator();
label_8:
        while (iterator2.hasNext())
        {
          Seq seq2 = (Seq) this.assetDependencies.get((object) (string) iterator2.next());
          if (seq2 != null)
          {
            Iterator iterator3 = seq2.iterator();
            while (true)
            {
              if (iterator3.hasNext())
              {
                string str = (string) iterator3.next();
                int num = objectIntMap.get((object) str, 0) + 1;
                objectIntMap.put((object) str, num);
              }
              else
                goto label_8;
            }
          }
        }
        Iterator iterator4 = seq1.iterator();
        while (true)
        {
          string fileName;
          do
          {
            if (iterator4.hasNext())
              fileName = (string) iterator4.next();
            else
              goto label_3;
          }
          while (objectIntMap.get((object) fileName, 0) != 0);
          this.unload(fileName);
        }
      }
      this.assets.clear();
      this.assetTypes.clear();
      this.assetDependencies.clear();
      this.loaded = 0;
      this.toLoad = 0;
      this.peakTasks = 0;
      this.loadQueue.clear();
      ((Vector) this.tasks).clear();
    }

    [Modifiers]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024loadRun\u00240()
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual FileHandleResolver getFileHandleResolver() => this.resolver;

    [Signature("<T:Ljava/lang/Object;>(Larc/assets/AssetDescriptor<TT;>;)TT;")]
    [LineNumberTable(127)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual object get(AssetDescriptor assetDescriptor) => this.get(assetDescriptor.__\u003C\u003EfileName, assetDescriptor.__\u003C\u003Etype);

    [LineNumberTable(new byte[] {82, 159, 19, 112, 63, 1, 166})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool contains(string fileName)
    {
      if (((Vector) this.tasks).size() > 0 && String.instancehelper_equals(((AssetLoadingTask) ((Vector) this.tasks).firstElement()).assetDesc.__\u003C\u003EfileName, (object) fileName))
        return true;
      for (int index = 0; index < this.loadQueue.size; ++index)
      {
        if (String.instancehelper_equals(((AssetDescriptor) this.loadQueue.get(index)).__\u003C\u003EfileName, (object) fileName))
          return true;
      }
      return this.isLoaded(fileName);
    }

    [LineNumberTable(new byte[] {92, 110, 118, 190, 112, 114, 30, 230, 69})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool contains(string fileName, Class type)
    {
      if (((Vector) this.tasks).size() > 0)
      {
        AssetDescriptor assetDesc = ((AssetLoadingTask) ((Vector) this.tasks).firstElement()).assetDesc;
        if (object.ReferenceEquals((object) assetDesc.__\u003C\u003Etype, (object) type) && String.instancehelper_equals(assetDesc.__\u003C\u003EfileName, (object) fileName))
          return true;
      }
      for (int index = 0; index < this.loadQueue.size; ++index)
      {
        AssetDescriptor assetDescriptor = (AssetDescriptor) this.loadQueue.get(index);
        if (object.ReferenceEquals((object) assetDescriptor.__\u003C\u003Etype, (object) type) && String.instancehelper_equals(assetDescriptor.__\u003C\u003EfileName, (object) fileName))
          return true;
      }
      return this.isLoaded(fileName, type);
    }

    [Signature("<T:Ljava/lang/Object;>(TT;)Z")]
    [LineNumberTable(new byte[] {160, 107, 119, 101, 127, 1, 119, 116, 98})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool containsAsset(object asset)
    {
      ObjectMap objectMap = (ObjectMap) this.assets.get((object) Object.instancehelper_getClass(asset));
      if (objectMap == null)
        return false;
      ObjectMap.Keys keys = objectMap.keys().iterator();
      while (((Iterator) keys).hasNext())
      {
        string str = (string) ((Iterator) keys).next();
        object objA = ((RefCountedContainer) objectMap.get((object) str)).getObject((Class) ClassLiteral<Object>.Value);
        if (object.ReferenceEquals(objA, asset) || Object.instancehelper_equals(asset, objA))
          return true;
      }
      return false;
    }

    [LineNumberTable(250)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool isLoaded(AssetDescriptor assetDesc) => this.isLoaded(assetDesc.__\u003C\u003EfileName);

    [LineNumberTable(473)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual bool isFinished() => this.loadQueue.size == 0 && ((Vector) this.tasks).size() == 0;

    [LineNumberTable(new byte[] {161, 108, 104, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finishLoading()
    {
      while (!this.update())
        Threads.yield();
    }

    [LineNumberTable(new byte[] {161, 117, 108})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void finishLoadingAsset(AssetDescriptor assetDesc) => this.finishLoadingAsset(assetDesc.__\u003C\u003EfileName);

    [LineNumberTable(705)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual int getQueuedAssets() => this.loadQueue.size + ((Vector) this.tasks).size();

    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void setErrorListener(AssetErrorListener listener) => this.listener = listener;

    [LineNumberTable(new byte[] {162, 103, 102, 107})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void dispose()
    {
      this.clear();
      this.executor.dispose();
    }

    [LineNumberTable(new byte[] {162, 154, 114, 127, 9})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual int getReferenceCount(string fileName)
    {
      Class @class = (Class) this.assetTypes.get((object) fileName);
      if (@class == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      return ((RefCountedContainer) ((ObjectMap) this.assets.get((object) @class)).get((object) fileName)).getRefCount();
    }

    [LineNumberTable(new byte[] {162, 163, 114, 127, 9, 127, 3})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual void setReferenceCount(string fileName, int refCount)
    {
      Class @class = (Class) this.assetTypes.get((object) fileName);
      if (@class == null)
      {
        string message = new StringBuilder().append("Asset not loaded: ").append(fileName).toString();
        Throwable.__\u003CsuppressFillInStackTrace\u003E();
        throw new ArcRuntimeException(message);
      }
      ((RefCountedContainer) ((ObjectMap) this.assets.get((object) @class)).get((object) fileName)).setRefCount(refCount);
    }

    [LineNumberTable(new byte[] {162, 170, 102, 127, 9, 104, 140, 114, 126, 147, 141, 108, 142, 100, 108, 127, 1, 105, 108, 98, 140, 108, 101})]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual string getDiagnostics()
    {
      StringBuilder stringBuilder = new StringBuilder();
      ObjectMap.Keys keys = this.assetTypes.keys().iterator();
      while (((Iterator) keys).hasNext())
      {
        string str1 = (string) ((Iterator) keys).next();
        stringBuilder.append(str1);
        stringBuilder.append(", ");
        Class @class = (Class) this.assetTypes.get((object) str1);
        RefCountedContainer countedContainer = (RefCountedContainer) ((ObjectMap) this.assets.get((object) @class)).get((object) str1);
        Seq seq = (Seq) this.assetDependencies.get((object) str1);
        stringBuilder.append(@class.getSimpleName());
        stringBuilder.append(", refs: ");
        stringBuilder.append(countedContainer.getRefCount());
        if (seq != null)
        {
          stringBuilder.append(", deps: [");
          Iterator iterator = seq.iterator();
          while (iterator.hasNext())
          {
            string str2 = (string) iterator.next();
            stringBuilder.append(str2);
            stringBuilder.append(",");
          }
          stringBuilder.append("]");
        }
        stringBuilder.append("\n");
      }
      return stringBuilder.toString();
    }

    [Signature("(Ljava/lang/String;)Larc/struct/Seq<Ljava/lang/String;>;")]
    [LineNumberTable(830)]
    [MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
    public virtual Seq getDependencies(string fileName) => (Seq) this.assetDependencies.get((object) fileName);

    [HideFromJava]
    public virtual bool isDisposed() => Disposable.\u003Cdefault\u003EisDisposed((Disposable) this);

    [EnclosingMethod(null, "loadRun", "(Ljava.lang.String;Ljava.lang.Class;Ljava.lang.Runnable;Ljava.lang.Runnable;)Larc.assets.AssetDescriptor;")]
    [SpecialName]
    internal class \u0031 : CustomLoader
    {
      [Modifiers]
      internal Runnable val\u0024loadasync;
      [Modifiers]
      internal Runnable val\u0024loadsync;
      [Modifiers]
      internal AssetManager this\u00240;

      [LineNumberTable(326)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] AssetManager obj0, [In] Runnable obj1, [In] Runnable obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024loadasync = obj1;
        this.val\u0024loadsync = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector();
      }

      [LineNumberTable(new byte[] {160, 215, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void loadAsync(
        [In] AssetManager obj0,
        [In] string obj1,
        [In] Fi obj2,
        [In] AssetLoaderParameters obj3)
      {
        this.val\u0024loadasync.run();
      }

      [LineNumberTable(new byte[] {160, 220, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object loadSync(
        [In] AssetManager obj0,
        [In] string obj1,
        [In] Fi obj2,
        [In] AssetLoaderParameters obj3)
      {
        this.val\u0024loadsync.run();
        return base.loadSync(obj0, obj1, obj2, obj3);
      }
    }

    [EnclosingMethod(null, "load", "(Larc.assets.Loadable;)Larc.assets.AssetDescriptor;")]
    [SpecialName]
    internal class \u0032 : AsynchronousAssetLoader
    {
      [Modifiers]
      internal Loadable val\u0024load;
      [Modifiers]
      internal AssetManager this\u00240;

      [LineNumberTable(350)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0032([In] AssetManager obj0, [In] FileHandleResolver obj1, [In] Loadable obj2)
      {
        this.this\u00240 = obj0;
        this.val\u0024load = obj2;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
      }

      [LineNumberTable(new byte[] {160, 239, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override void loadAsync(
        [In] AssetManager obj0,
        [In] string obj1,
        [In] Fi obj2,
        [In] AssetLoaderParameters obj3)
      {
        this.val\u0024load.loadAsync();
      }

      [LineNumberTable(new byte[] {160, 244, 107})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override object loadSync(
        [In] AssetManager obj0,
        [In] string obj1,
        [In] Fi obj2,
        [In] AssetLoaderParameters obj3)
      {
        this.val\u0024load.loadSync();
        return (object) this.val\u0024load;
      }

      [Signature("(Ljava/lang/String;Larc/files/Fi;Larc/assets/AssetLoaderParameters;)Larc/struct/Seq<Larc/assets/AssetDescriptor;>;")]
      [LineNumberTable(364)]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public override Seq getDependencies([In] string obj0, [In] Fi obj1, [In] AssetLoaderParameters obj2) => this.val\u0024load.getDependencies();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Runnable
    {
      internal __\u003C\u003EAnon0()
      {
      }

      public void run() => AssetManager.lambda\u0024loadRun\u00240();
    }
  }
}
