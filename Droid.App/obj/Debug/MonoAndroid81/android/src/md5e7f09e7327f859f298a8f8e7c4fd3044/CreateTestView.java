package md5e7f09e7327f859f298a8f8e7c4fd3044;


public class CreateTestView
	extends md5231beb04e46a1dc811e36737109a7a02.MvxActivity_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Droid.App.CreateTestView, Droid.App", CreateTestView.class, __md_methods);
	}


	public CreateTestView ()
	{
		super ();
		if (getClass () == CreateTestView.class)
			mono.android.TypeManager.Activate ("Droid.App.CreateTestView, Droid.App", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
