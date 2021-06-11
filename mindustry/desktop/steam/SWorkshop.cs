// Decompiled with JetBrains decompiler
// Type: mindustry.desktop.steam.SWorkshop
// Assembly: Mindustry, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F7780785-7FAB-4DA9-991F-68694F84D8C1
// Assembly location: D:\workspace\Java\Mindustry-126.2\desktop\build\libs\Mindustry.exe

using arc;
using arc.@struct;
using arc.files;
using arc.func;
using arc.scene.style;
using arc.scene.ui;
using arc.scene.ui.layout;
using arc.util;
using com.codedisaster.steamworks;
using ikvm.@internal;
using IKVM.Attributes;
using IKVM.Runtime;
using java.lang;
using mindustry.game;
using mindustry.gen;
using mindustry.maps;
using mindustry.mod;
using mindustry.type;
using mindustry.ui.dialogs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace mindustry.desktop.steam
{
  public class SWorkshop : Object, SteamUGCCallback
  {
    internal SteamUGC __\u003C\u003Eugc;
    [Signature("Larc/struct/ObjectMap<Ljava/lang/Class<+Lmindustry/type/Publishable;>;Larc/struct/Seq<Larc/files/Fi;>;>;")]
    private ObjectMap workshopFiles;
    [Signature("Larc/struct/ObjectMap<Lcom/codedisaster/steamworks/SteamUGCQuery;Larc/func/Cons2<Larc/struct/Seq<Lcom/codedisaster/steamworks/SteamUGCDetails;>;Lcom/codedisaster/steamworks/SteamResult;>;>;")]
    private ObjectMap detailHandlers;
    [Signature("Larc/struct/Seq<Larc/func/Cons<Lcom/codedisaster/steamworks/SteamPublishedFileID;>;>;")]
    private Seq itemHandlers;
    [Signature("Larc/struct/ObjectMap<Lcom/codedisaster/steamworks/SteamPublishedFileID;Ljava/lang/Runnable;>;")]
    private ObjectMap updatedHandlers;

    [LineNumberTable(new byte[] {159, 171, 232, 57, 140, 107, 107, 107, 171, 108, 103, 102, 141, 191, 2, 135, 127, 18, 127, 18, 159, 3, 124, 170, 181})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public SWorkshop()
    {
      SWorkshop sworkshop = this;
      this.__\u003C\u003Eugc = new SteamUGC((SteamUGCCallback) this);
      this.workshopFiles = new ObjectMap();
      this.detailHandlers = new ObjectMap();
      this.itemHandlers = new Seq();
      this.updatedHandlers = new ObjectMap();
      SteamPublishedFileID[] publishedFileIds = new SteamPublishedFileID[this.__\u003C\u003Eugc.getNumSubscribedItems()];
      SteamUGC.ItemInstallInfo itemInstallInfo = new SteamUGC.ItemInstallInfo();
      this.__\u003C\u003Eugc.getSubscribedItems(publishedFileIds);
      Seq seq = Seq.with((object[]) publishedFileIds).map((Func) new SWorkshop.__\u003C\u003EAnon0(this, itemInstallInfo)).select((Boolf) new SWorkshop.__\u003C\u003EAnon1());
      this.workshopFiles.put((object) ClassLiteral<Map>.Value, (object) seq.select((Boolf) new SWorkshop.__\u003C\u003EAnon2()).map((Func) new SWorkshop.__\u003C\u003EAnon3()));
      this.workshopFiles.put((object) ClassLiteral<Schematic>.Value, (object) seq.select((Boolf) new SWorkshop.__\u003C\u003EAnon4()).map((Func) new SWorkshop.__\u003C\u003EAnon5()));
      this.workshopFiles.put((object) ClassLiteral<Mods.LoadedMod>.Value, (object) seq.select((Boolf) new SWorkshop.__\u003C\u003EAnon6()));
      if (!((Seq) this.workshopFiles.get((object) ClassLiteral<Map>.Value)).isEmpty())
        SAchievement.__\u003C\u003EdownloadMapWorkshop.complete();
      this.workshopFiles.each((Cons2) new SWorkshop.__\u003C\u003EAnon7());
    }

    [Signature("(Ljava/lang/Class<+Lmindustry/type/Publishable;>;)Larc/struct/Seq<Larc/files/Fi;>;")]
    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual Seq getWorkshopFiles(Class type) => (Seq) this.workshopFiles.get((object) type, (Prov) new SWorkshop.__\u003C\u003EAnon8());

    [LineNumberTable(new byte[] {34, 110, 103, 159, 0, 111, 255, 0, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void viewListing(Publishable p)
    {
      long id = Strings.parseLong(p.getSteamID(), -1L);
      SteamPublishedFileID publishedFileID = new SteamPublishedFileID(id);
      Log.info((object) new StringBuilder().append("Handle = ").append(id).toString());
      Vars.ui.loadfrag.show();
      this.query(this.__\u003C\u003Eugc.createQueryUGCDetailsRequest(publishedFileID), (Cons2) new SWorkshop.__\u003C\u003EAnon10(this, publishedFileID, p));
    }

    [LineNumberTable(new byte[] {10, 127, 5, 104, 106, 103, 161, 104, 106, 161, 114})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void publish(Publishable p)
    {
      Log.info((object) new StringBuilder().append("publish(): ").append(p.steamTitle()).toString());
      if (p.hasSteamID())
      {
        Log.info((object) "Content already published, redirecting to ID.");
        this.viewListing(p);
      }
      else if (!p.prePublish())
        Log.info((object) "Rejecting due to pre-publish.");
      else
        this.showPublish((Cons) new SWorkshop.__\u003C\u003EAnon9(this, p));
    }

    [LineNumberTable(new byte[] {27, 103, 105, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void updateItem(Publishable p, string changelog)
    {
      long id = Strings.parseLong(p.getSteamID(), -1L);
      this.update(p, new SteamPublishedFileID(id), changelog);
    }

    [Signature("(Larc/func/Cons<Lcom/codedisaster/steamworks/SteamPublishedFileID;>;)V")]
    [LineNumberTable(new byte[] {160, 66, 107, 103, 127, 17, 102, 159, 10, 134, 255, 13, 70, 102, 103})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void showPublish([In] Cons obj0)
    {
      BaseDialog baseDialog = new BaseDialog("@confirm");
      baseDialog.setFillParent(false);
      Table cont = baseDialog.__\u003C\u003Econt;
      object obj = (object) "@publish.confirm";
      CharSequence charSequence;
      charSequence.__\u003Cref\u003E = (__Null) obj;
      CharSequence text = charSequence;
      cont.add(text).width(600f).wrap();
      baseDialog.addCloseButton();
      baseDialog.__\u003C\u003Ebuttons.button("@eula", (Drawable) Icon.link, (Runnable) new SWorkshop.__\u003C\u003EAnon13()).size(210f, 64f);
      baseDialog.__\u003C\u003Ebuttons.button("@ok", (Drawable) Icon.ok, (Runnable) new SWorkshop.__\u003C\u003EAnon14(this, obj0, baseDialog)).size(170f, 64f);
      baseDialog.show();
    }

    [LineNumberTable(new byte[] {103, 127, 8, 159, 1, 255, 2, 85})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void update([In] Publishable obj0, [In] SteamPublishedFileID obj1, [In] string obj2)
    {
      Log.info("Calling update(@) @", (object) obj0.steamTitle(), (object) Long.valueOf(obj1.handle()));
      string str = new StringBuilder().append(obj1.handle()).append("").toString();
      this.updateItem(obj1, (Cons) new SWorkshop.__\u003C\u003EAnon11(this, obj0, str, obj2), (Runnable) new SWorkshop.__\u003C\u003EAnon12(obj0, str));
    }

    [Signature("(Lcom/codedisaster/steamworks/SteamUGCQuery;Larc/func/Cons2<Larc/struct/Seq<Lcom/codedisaster/steamworks/SteamUGCDetails;>;Lcom/codedisaster/steamworks/SteamResult;>;)V")]
    [LineNumberTable(new byte[] {160, 85, 127, 0, 110, 109})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void query([In] SteamUGCQuery obj0, [In] Cons2 obj1)
    {
      Log.info((object) new StringBuilder().append("POST QUERY ").append((object) obj0).toString());
      this.detailHandlers.put((object) obj0, (object) obj1);
      this.__\u003C\u003Eugc.sendQueryUGCRequest(obj0);
    }

    [Signature("(Lcom/codedisaster/steamworks/SteamPublishedFileID;Larc/func/Cons<Lcom/codedisaster/steamworks/SteamUGCUpdateHandle;>;Ljava/lang/Runnable;)V")]
    [LineNumberTable(new byte[] {160, 92, 114, 158, 103, 138, 134, 252, 74, 223, 1, 226, 61, 97, 111, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void updateItem([In] SteamPublishedFileID obj0, [In] Cons obj1, [In] Runnable obj2)
    {
      Exception exception;
      try
      {
        SteamUGCUpdateHandle steamUgcUpdateHandle = this.__\u003C\u003Eugc.startItemUpdate(1127400, obj0);
        Log.info("begin updateItem(@)", (object) Long.valueOf(obj0.handle()));
        obj1.get((object) steamUgcUpdateHandle);
        Log.info((object) "Tagged.");
        SteamUGC.ItemUpdateInfo itemUpdateInfo = new SteamUGC.ItemUpdateInfo();
        Vars.ui.loadfrag.setProgress((Floatp) new SWorkshop.__\u003C\u003EAnon15(this, steamUgcUpdateHandle, itemUpdateInfo));
        this.updatedHandlers.put((object) obj0, (object) obj2);
        return;
      }
      catch (Exception ex)
      {
        exception = (Exception) ByteCodeHelper.MapException<Exception>(ex, (ByteCodeHelper.MapFlags) 0);
      }
      Exception th = exception;
      Vars.ui.loadfrag.hide();
      Log.err(th);
    }

    [LineNumberTable(new byte[] {99, 127, 15})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal virtual void viewListingID([In] SteamPublishedFileID obj0) => SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage(new StringBuilder().append("steam://url/CommunityFilePage/").append(obj0.handle()).toString());

    [Modifiers]
    [LineNumberTable(new byte[] {159, 178, 110})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private Fi lambda\u0024new\u00240([In] SteamUGC.ItemInstallInfo obj0, [In] SteamPublishedFileID obj1)
    {
      this.__\u003C\u003Eugc.getItemInstallInfo(obj1, obj0);
      return new Fi(obj0.getFolder());
    }

    [Modifiers]
    [LineNumberTable(38)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00241([In] Fi obj0) => obj0 != null && obj0.list().Length > 0;

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00242([In] Fi obj0) => obj0.list().Length == 1 && String.instancehelper_equals(obj0.list()[0].extension(), (object) "msav");

    [Modifiers]
    [LineNumberTable(40)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Fi lambda\u0024new\u00243([In] Fi obj0) => obj0.list()[0];

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00244([In] Fi obj0) => obj0.list().Length == 1 && String.instancehelper_equals(obj0.list()[0].extension(), (object) "msch");

    [Modifiers]
    [LineNumberTable(41)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Fi lambda\u0024new\u00245([In] Fi obj0) => obj0.list()[0];

    [Modifiers]
    [LineNumberTable(42)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static bool lambda\u0024new\u00246([In] Fi obj0) => obj0.child("mod.json").exists() || obj0.child("mod.hjson").exists();

    [Modifiers]
    [LineNumberTable(new byte[] {159, 191, 127, 8})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024new\u00247([In] Class obj0, [In] Seq obj1) => Log.info("Fetched content (@): @", (object) obj0.getSimpleName(), (object) Integer.valueOf(obj1.size));

    [Modifiers]
    [LineNumberTable(54)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static Seq lambda\u0024getWorkshopFiles\u00248() => new Seq(0);

    [Modifiers]
    [LineNumberTable(72)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024publish\u00249([In] Publishable obj0, [In] SteamPublishedFileID obj1) => this.update(obj0, obj1, (string) null);

    [Modifiers]
    [LineNumberTable(new byte[] {40, 111, 159, 1, 113, 108, 127, 5, 117, 159, 0, 107, 103, 127, 12, 134, 191, 13, 134, 255, 13, 86, 102, 103, 101, 159, 22, 114, 102, 145, 159, 14, 98, 159, 10})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024viewListing\u002412(
      [In] SteamPublishedFileID obj0,
      [In] Publishable obj1,
      [In] Seq obj2,
      [In] SteamResult obj3)
    {
      Vars.ui.loadfrag.hide();
      Log.info((object) new StringBuilder().append("Fetch result = ").append((object) obj3).toString());
      if (object.ReferenceEquals((object) obj3, (object) SteamResult.__\u003C\u003EOK))
      {
        SteamUGCDetails steamUgcDetails = (SteamUGCDetails) obj2.first();
        Log.info((object) new StringBuilder().append("Details result = ").append((object) steamUgcDetails.getResult()).toString());
        if (object.ReferenceEquals((object) steamUgcDetails.getResult(), (object) SteamResult.__\u003C\u003EOK))
        {
          if (steamUgcDetails.getOwnerID().equals((object) SVars.user.__\u003C\u003Euser.getSteamID()))
          {
            BaseDialog baseDialog = new BaseDialog("@workshop.info");
            baseDialog.setFillParent(false);
            Table cont = baseDialog.__\u003C\u003Econt;
            object obj = (object) "@workshop.menu";
            CharSequence charSequence;
            charSequence.__\u003Cref\u003E = (__Null) obj;
            CharSequence text = charSequence;
            cont.add(text).pad(20f);
            baseDialog.addCloseButton();
            baseDialog.__\u003C\u003Ebuttons.button("@view.workshop", (Drawable) Icon.link, (Runnable) new SWorkshop.__\u003C\u003EAnon16(this, obj0, baseDialog)).size(210f, 64f);
            baseDialog.__\u003C\u003Ebuttons.button("@workshop.update", (Drawable) Icon.up, (Runnable) new SWorkshop.__\u003C\u003EAnon17(this, obj1, baseDialog)).size(210f, 64f);
            baseDialog.show();
          }
          else
            SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage(new StringBuilder().append("steam://url/CommunityFilePage/").append(steamUgcDetails.getPublishedFileID().handle()).toString());
        }
        else if (object.ReferenceEquals((object) steamUgcDetails.getResult(), (object) SteamResult.__\u003C\u003EFileNotFound))
        {
          obj1.removeSteamID();
          Vars.ui.showErrorMessage("@missing");
        }
        else
          Vars.ui.showErrorMessage(Core.bundle.format("workshop.error", (object) steamUgcDetails.getResult().name()));
      }
      else
        Vars.ui.showErrorMessage(Core.bundle.format("workshop.error", (object) obj3.name()));
    }

    [Modifiers]
    [LineNumberTable(new byte[] {107, 104, 180, 103, 140, 116, 126, 122, 122, 99, 147, 153, 104, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024update\u002413(
      [In] Publishable obj0,
      [In] string obj1,
      [In] string obj2,
      [In] SteamUGCUpdateHandle obj3)
    {
      if (obj0.steamDescription() != null)
        this.__\u003C\u003Eugc.setItemDescription(obj3, obj0.steamDescription());
      Seq seq = obj0.extraTags();
      seq.add((object) obj0.steamTag());
      this.__\u003C\u003Eugc.setItemTitle(obj3, obj0.steamTitle());
      this.__\u003C\u003Eugc.setItemTags(obj3, (string[]) seq.toArray((Class) ClassLiteral<String>.Value));
      this.__\u003C\u003Eugc.setItemPreview(obj3, obj0.createSteamPreview(obj1).absolutePath());
      this.__\u003C\u003Eugc.setItemContent(obj3, obj0.createSteamFolder(obj1).absolutePath());
      if (obj2 == null)
        this.__\u003C\u003Eugc.setItemVisibility(obj3, SteamRemoteStorage.PublishedFileVisibility.__\u003C\u003EPrivate);
      this.__\u003C\u003Eugc.submitItemUpdate(obj3, obj2 != null ? obj2 : "<Created>");
      if (!(obj0 is Map))
        return;
      SAchievement.__\u003C\u003EpublishMap.complete();
    }

    [Modifiers]
    [LineNumberTable(176)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024update\u002414([In] Publishable obj0, [In] string obj1) => obj0.addSteamID(obj1);

    [Modifiers]
    [LineNumberTable(185)]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void lambda\u0024showPublish\u002415() => SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage("https://steamcommunity.com/sharedfiles/workshoplegalagreement");

    [Modifiers]
    [LineNumberTable(new byte[] {160, 75, 106, 108, 118, 116, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024showPublish\u002416([In] Cons obj0, [In] BaseDialog obj1)
    {
      Log.info((object) "Accepted, publishing item...");
      this.itemHandlers.add((object) obj0);
      this.__\u003C\u003Eugc.createItem(1127400, SteamRemoteStorage.WorkshopFileType.__\u003C\u003ECommunity);
      Vars.ui.loadfrag.show("@publishing");
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {160, 101, 110, 127, 20, 109, 116, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private float lambda\u0024updateItem\u002417(
      [In] SteamUGCUpdateHandle obj0,
      [In] SteamUGC.ItemUpdateInfo obj1)
    {
      SteamUGC.ItemUpdateStatus itemUpdateProgress = this.__\u003C\u003Eugc.getItemUpdateProgress(obj0, obj1);
      Vars.ui.loadfrag.setText(new StringBuilder().append("@").append(String.instancehelper_toLowerCase(itemUpdateProgress.name())).toString());
      if (!object.ReferenceEquals((object) itemUpdateProgress, (object) SteamUGC.ItemUpdateStatus.__\u003C\u003EInvalid))
        return (float) itemUpdateProgress.ordinal() / (float) SteamUGC.ItemUpdateStatus.values().Length;
      Vars.ui.loadfrag.setText("@done");
      return 1f;
    }

    [Modifiers]
    [LineNumberTable(new byte[] {55, 103, 102})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024viewListing\u002410([In] SteamPublishedFileID obj0, [In] BaseDialog obj1)
    {
      this.viewListingID(obj0);
      obj1.hide();
    }

    [Modifiers]
    [LineNumberTable(new byte[] {60, 237, 83, 134})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    private void lambda\u0024viewListing\u002411([In] Publishable obj0, [In] BaseDialog obj1) => new SWorkshop.\u0031(this, "@workshop.update", obj0, obj1).show();

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onRequestUGCDetails(SteamUGCDetails details, SteamResult result)
    {
    }

    [LineNumberTable(new byte[] {160, 124, 159, 0, 113, 106, 103, 121, 102, 102, 107, 26, 198, 121, 98, 106, 191, 1, 143, 138})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUGCQueryCompleted(
      SteamUGCQuery query,
      int numResultsReturned,
      int totalMatchingResults,
      bool isCachedData,
      SteamResult result)
    {
      Log.info((object) new StringBuilder().append("GET QUERY ").append((object) query).toString());
      if (this.detailHandlers.containsKey((object) query))
      {
        Log.info((object) "Query being handled...");
        if (numResultsReturned > 0)
        {
          Log.info("@ q results", (object) Integer.valueOf(numResultsReturned));
          Seq seq = new Seq();
          for (int index = 0; index < numResultsReturned; ++index)
          {
            seq.add((object) new SteamUGCDetails());
            this.__\u003C\u003Eugc.getQueryUGCResult(query, index, (SteamUGCDetails) seq.get(index));
          }
          ((Cons2) this.detailHandlers.get((object) query)).get((object) seq, (object) result);
        }
        else
        {
          Log.info((object) "Nothing found.");
          ((Cons2) this.detailHandlers.get((object) query)).get((object) new Seq(), (object) SteamResult.__\u003C\u003EFileNotFound);
        }
        this.detailHandlers.remove((object) query);
      }
      else
        Log.info((object) "Query not handled.");
    }

    [LineNumberTable(new byte[] {160, 149, 102, 110, 121, 106})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onSubscribeItem(SteamPublishedFileID publishedFileID, SteamResult result)
    {
      SteamUGC.ItemInstallInfo installInfo = new SteamUGC.ItemInstallInfo();
      this.__\u003C\u003Eugc.getItemInstallInfo(publishedFileID, installInfo);
      Log.info("Item subscribed from @", (object) installInfo.getFolder());
      SAchievement.__\u003C\u003EdownloadMapWorkshop.complete();
    }

    [LineNumberTable(new byte[] {160, 157, 102, 110, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUnsubscribeItem(SteamPublishedFileID publishedFileID, SteamResult result)
    {
      SteamUGC.ItemInstallInfo installInfo = new SteamUGC.ItemInstallInfo();
      this.__\u003C\u003Eugc.getItemInstallInfo(publishedFileID, installInfo);
      Log.info("Item unsubscribed from @", (object) installInfo.getFolder());
    }

    [LineNumberTable(new byte[] {160, 164, 127, 10, 109, 109, 106, 152, 191, 9, 143, 144})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onCreateItem(
      SteamPublishedFileID publishedFileID,
      bool needsToAcceptWLA,
      SteamResult result)
    {
      Log.info((object) new StringBuilder().append("onCreateItem(").append((object) result).append(")").toString());
      if (!this.itemHandlers.isEmpty())
      {
        if (object.ReferenceEquals((object) result, (object) SteamResult.__\u003C\u003EOK))
        {
          Log.info((object) "Passing to first handler.");
          ((Cons) this.itemHandlers.first()).get((object) publishedFileID);
        }
        else
          Vars.ui.showErrorMessage(Core.bundle.format("publish.error", (object) result.name()));
        this.itemHandlers.remove(0);
      }
      else
        Log.err("No handlers for createItem()");
    }

    [LineNumberTable(new byte[] {159, 69, 162, 111, 127, 12, 141, 127, 15, 99, 180, 110, 184, 159, 9})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onSubmitItemUpdate(
      SteamPublishedFileID publishedFileID,
      bool needsToAcceptWLA,
      SteamResult result)
    {
      int num = needsToAcceptWLA ? 1 : 0;
      Vars.ui.loadfrag.hide();
      Log.info("onsubmititemupdate @ @ @", (object) Long.valueOf(publishedFileID.handle()), (object) Boolean.valueOf(num != 0), (object) result);
      if (object.ReferenceEquals((object) result, (object) SteamResult.__\u003C\u003EOK))
      {
        SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage(new StringBuilder().append("steam://url/CommunityFilePage/").append(publishedFileID.handle()).toString());
        if (num != 0)
          SVars.net.__\u003C\u003Efriends.activateGameOverlayToWebPage("https://steamcommunity.com/sharedfiles/workshoplegalagreement");
        if (!this.updatedHandlers.containsKey((object) publishedFileID))
          return;
        ((Runnable) this.updatedHandlers.get((object) publishedFileID)).run();
      }
      else
        Vars.ui.showErrorMessage(Core.bundle.format("publish.error", (object) result.name()));
    }

    [LineNumberTable(new byte[] {160, 200, 106, 102, 110, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onDownloadItemResult(
      int appID,
      SteamPublishedFileID publishedFileID,
      SteamResult result)
    {
      SAchievement.__\u003C\u003EdownloadMapWorkshop.complete();
      SteamUGC.ItemInstallInfo installInfo = new SteamUGC.ItemInstallInfo();
      this.__\u003C\u003Eugc.getItemInstallInfo(publishedFileID, installInfo);
      Log.info("Item downloaded to @", (object) installInfo.getFolder());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onUserFavoriteItemsListChanged(
      SteamPublishedFileID publishedFileID,
      bool wasAddRequest,
      SteamResult result)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onSetUserItemVote(
      SteamPublishedFileID publishedFileID,
      bool voteUp,
      SteamResult result)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onGetUserItemVote(
      SteamPublishedFileID publishedFileID,
      bool votedUp,
      bool votedDown,
      bool voteSkipped,
      SteamResult result)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onStartPlaytimeTracking(SteamResult result)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onStopPlaytimeTracking(SteamResult result)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onStopPlaytimeTrackingForAllItems(SteamResult result)
    {
    }

    [LineNumberTable(new byte[] {160, 238, 102, 110, 121})]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public virtual void onDeleteItem(SteamPublishedFileID publishedFileID, SteamResult result)
    {
      SteamUGC.ItemInstallInfo installInfo = new SteamUGC.ItemInstallInfo();
      this.__\u003C\u003Eugc.getItemInstallInfo(publishedFileID, installInfo);
      Log.info("Item removed from @", (object) installInfo.getFolder());
    }

    [Modifiers]
    public SteamUGC ugc
    {
      [HideFromJava] get => this.__\u003C\u003Eugc;
      [HideFromJava] [param: In] private set => this.__\u003C\u003Eugc = value;
    }

    [EnclosingMethod(null, "viewListing", "(Lmindustry.type.Publishable;)V")]
    [SpecialName]
    internal class \u0031 : BaseDialog
    {
      [Modifiers]
      internal Publishable val\u0024p;
      [Modifiers]
      internal BaseDialog val\u0024dialog;
      [Modifiers]
      internal SWorkshop this\u00240;

      [SpecialName]
      [MethodImpl(MethodImplOptions.NoInlining)]
      public new static void __\u003Cclinit\u003E()
      {
      }

      [Modifiers]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private static void lambda\u0024new\u00240([In] string obj0)
      {
      }

      [Modifiers]
      [LineNumberTable(new byte[] {68, 104, 106, 161, 116, 127, 36, 102, 102})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      private void lambda\u0024new\u00241([In] Publishable obj0, [In] TextArea obj1, [In] BaseDialog obj2)
      {
        if (!obj0.prePublish())
        {
          Log.info((object) "Rejecting due to pre-publish.");
        }
        else
        {
          Vars.ui.loadfrag.show("@publishing");
          SWorkshop this0 = this.this\u00240;
          Publishable p = obj0;
          string text = obj1.getText();
          object obj3 = (object) "\n";
          object obj4 = (object) "\r";
          CharSequence charSequence1;
          charSequence1.__\u003Cref\u003E = (__Null) obj4;
          CharSequence charSequence2 = charSequence1;
          object obj5 = obj3;
          charSequence1.__\u003Cref\u003E = (__Null) obj5;
          CharSequence charSequence3 = charSequence1;
          string changelog = String.instancehelper_replace(text, charSequence2, charSequence3);
          this0.updateItem(p, changelog);
          obj2.hide();
          this.hide();
        }
      }

      [LineNumberTable(new byte[] {60, 127, 0, 103, 127, 22, 108, 127, 21, 107, 127, 6, 255, 10, 75, 124})]
      [MethodImpl(MethodImplOptions.NoInlining)]
      internal \u0031([In] SWorkshop obj0, [In] string obj1, [In] Publishable obj2, [In] BaseDialog obj3)
      {
        this.this\u00240 = obj0;
        this.val\u0024p = obj2;
        this.val\u0024dialog = obj3;
        // ISSUE: explicit constructor call
        base.\u002Ector(obj1);
        SWorkshop.\u0031 obj4 = this;
        this.setFillParent(false);
        Table table = this.__\u003C\u003Econt.margin(10f);
        object obj5 = (object) "@changelog";
        CharSequence charSequence;
        charSequence.__\u003Cref\u003E = (__Null) obj5;
        CharSequence text = charSequence;
        table.add(text).padRight(6f);
        this.__\u003C\u003Econt.row();
        TextArea textArea = (TextArea) this.__\u003C\u003Econt.area("", (Cons) new SWorkshop.\u0031.__\u003C\u003EAnon0()).size(500f, 160f).get();
        textArea.setMaxLength(400);
        this.__\u003C\u003Ebuttons.defaults().size(120f, 54f).pad(4f);
        this.__\u003C\u003Ebuttons.button("@ok", (Runnable) new SWorkshop.\u0031.__\u003C\u003EAnon1(this, this.val\u0024p, textArea, this.val\u0024dialog));
        this.__\u003C\u003Ebuttons.button("@cancel", (Runnable) new SWorkshop.\u0031.__\u003C\u003EAnon2(this));
      }

      [HideFromJava]
      static \u0031() => BaseDialog.__\u003Cclinit\u003E();

      [SpecialName]
      private new sealed class __\u003C\u003EAnon0 : Cons
      {
        internal __\u003C\u003EAnon0()
        {
        }

        public void get([In] object obj0) => SWorkshop.\u0031.lambda\u0024new\u00240((string) obj0);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon1 : Runnable
      {
        private readonly SWorkshop.\u0031 arg\u00241;
        private readonly Publishable arg\u00242;
        private readonly TextArea arg\u00243;
        private readonly BaseDialog arg\u00244;

        internal __\u003C\u003EAnon1(
          [In] SWorkshop.\u0031 obj0,
          [In] Publishable obj1,
          [In] TextArea obj2,
          [In] BaseDialog obj3)
        {
          this.arg\u00241 = obj0;
          this.arg\u00242 = obj1;
          this.arg\u00243 = obj2;
          this.arg\u00244 = obj3;
        }

        public void run() => this.arg\u00241.lambda\u0024new\u00241(this.arg\u00242, this.arg\u00243, this.arg\u00244);
      }

      [SpecialName]
      private new sealed class __\u003C\u003EAnon2 : Runnable
      {
        private readonly SWorkshop.\u0031 arg\u00241;

        internal __\u003C\u003EAnon2([In] SWorkshop.\u0031 obj0) => this.arg\u00241 = obj0;

        public void run() => this.arg\u00241.hide();
      }
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon0 : Func
    {
      private readonly SWorkshop arg\u00241;
      private readonly SteamUGC.ItemInstallInfo arg\u00242;

      internal __\u003C\u003EAnon0([In] SWorkshop obj0, [In] SteamUGC.ItemInstallInfo obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public object get([In] object obj0) => (object) this.arg\u00241.lambda\u0024new\u00240(this.arg\u00242, (SteamPublishedFileID) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon1 : Boolf
    {
      internal __\u003C\u003EAnon1()
      {
      }

      public bool get([In] object obj0) => (SWorkshop.lambda\u0024new\u00241((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon2 : Boolf
    {
      internal __\u003C\u003EAnon2()
      {
      }

      public bool get([In] object obj0) => (SWorkshop.lambda\u0024new\u00242((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon3 : Func
    {
      internal __\u003C\u003EAnon3()
      {
      }

      public object get([In] object obj0) => (object) SWorkshop.lambda\u0024new\u00243((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon4 : Boolf
    {
      internal __\u003C\u003EAnon4()
      {
      }

      public bool get([In] object obj0) => (SWorkshop.lambda\u0024new\u00244((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon5 : Func
    {
      internal __\u003C\u003EAnon5()
      {
      }

      public object get([In] object obj0) => (object) SWorkshop.lambda\u0024new\u00245((Fi) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon6 : Boolf
    {
      internal __\u003C\u003EAnon6()
      {
      }

      public bool get([In] object obj0) => (SWorkshop.lambda\u0024new\u00246((Fi) obj0) ? 1 : 0) != 0;
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon7 : Cons2
    {
      internal __\u003C\u003EAnon7()
      {
      }

      public void get([In] object obj0, [In] object obj1) => SWorkshop.lambda\u0024new\u00247((Class) obj0, (Seq) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon8 : Prov
    {
      internal __\u003C\u003EAnon8()
      {
      }

      public object get() => (object) SWorkshop.lambda\u0024getWorkshopFiles\u00248();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon9 : Cons
    {
      private readonly SWorkshop arg\u00241;
      private readonly Publishable arg\u00242;

      internal __\u003C\u003EAnon9([In] SWorkshop obj0, [In] Publishable obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024publish\u00249(this.arg\u00242, (SteamPublishedFileID) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon10 : Cons2
    {
      private readonly SWorkshop arg\u00241;
      private readonly SteamPublishedFileID arg\u00242;
      private readonly Publishable arg\u00243;

      internal __\u003C\u003EAnon10([In] SWorkshop obj0, [In] SteamPublishedFileID obj1, [In] Publishable obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void get([In] object obj0, [In] object obj1) => this.arg\u00241.lambda\u0024viewListing\u002412(this.arg\u00242, this.arg\u00243, (Seq) obj0, (SteamResult) obj1);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon11 : Cons
    {
      private readonly SWorkshop arg\u00241;
      private readonly Publishable arg\u00242;
      private readonly string arg\u00243;
      private readonly string arg\u00244;

      internal __\u003C\u003EAnon11([In] SWorkshop obj0, [In] Publishable obj1, [In] string obj2, [In] string obj3)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
        this.arg\u00244 = obj3;
      }

      public void get([In] object obj0) => this.arg\u00241.lambda\u0024update\u002413(this.arg\u00242, this.arg\u00243, this.arg\u00244, (SteamUGCUpdateHandle) obj0);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon12 : Runnable
    {
      private readonly Publishable arg\u00241;
      private readonly string arg\u00242;

      internal __\u003C\u003EAnon12([In] Publishable obj0, [In] string obj1)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
      }

      public void run() => SWorkshop.lambda\u0024update\u002414(this.arg\u00241, this.arg\u00242);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon13 : Runnable
    {
      internal __\u003C\u003EAnon13()
      {
      }

      public void run() => SWorkshop.lambda\u0024showPublish\u002415();
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon14 : Runnable
    {
      private readonly SWorkshop arg\u00241;
      private readonly Cons arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon14([In] SWorkshop obj0, [In] Cons obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024showPublish\u002416(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon15 : Floatp
    {
      private readonly SWorkshop arg\u00241;
      private readonly SteamUGCUpdateHandle arg\u00242;
      private readonly SteamUGC.ItemUpdateInfo arg\u00243;

      internal __\u003C\u003EAnon15(
        [In] SWorkshop obj0,
        [In] SteamUGCUpdateHandle obj1,
        [In] SteamUGC.ItemUpdateInfo obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public float get() => this.arg\u00241.lambda\u0024updateItem\u002417(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon16 : Runnable
    {
      private readonly SWorkshop arg\u00241;
      private readonly SteamPublishedFileID arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon16([In] SWorkshop obj0, [In] SteamPublishedFileID obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024viewListing\u002410(this.arg\u00242, this.arg\u00243);
    }

    [SpecialName]
    private sealed class __\u003C\u003EAnon17 : Runnable
    {
      private readonly SWorkshop arg\u00241;
      private readonly Publishable arg\u00242;
      private readonly BaseDialog arg\u00243;

      internal __\u003C\u003EAnon17([In] SWorkshop obj0, [In] Publishable obj1, [In] BaseDialog obj2)
      {
        this.arg\u00241 = obj0;
        this.arg\u00242 = obj1;
        this.arg\u00243 = obj2;
      }

      public void run() => this.arg\u00241.lambda\u0024viewListing\u002411(this.arg\u00242, this.arg\u00243);
    }
  }
}
