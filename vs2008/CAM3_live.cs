using System;
using HalconDotNet;

public partial class HDevelopExport
{
    //public HTuple hv_ExpDefaultWinHandle;

    private bool exitloop3;
    public bool Exitloop3
    {
        get { return exitloop3; }
        set { exitloop3 = value; }
    }

    // Main procedure 
    private void action3()
    {


    // Local iconic variables 

    HObject ho_Image=null;

    // Local control variables 

    HTuple hv_AcqHandle = null;
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Image);

    // CAM 3 Poroznost
    HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1, 
        "default", -1, "false", "default", "GC2591MP_CAM_3", 0, -1, out hv_AcqHandle);
    HOperatorSet.GrabImageStart(hv_AcqHandle, -1);

    //while ((int)(1) != 0)
    while (exitloop3 == false)
    {
        ho_Image.Dispose();
        HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
        //Image Acquisition 01: Do something
        HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
    }
    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
    ho_Image.Dispose();

    }

    //public void InitHalcon()
    //{
    //  // Default settings used in HDevelop 
    //  HOperatorSet.SetSystem("width", 512);
    //  HOperatorSet.SetSystem("height", 512);
    //}

    public void RunCAM3(HTuple Window)
    {
    hv_ExpDefaultWinHandle = Window;
    action3();
    }

}

