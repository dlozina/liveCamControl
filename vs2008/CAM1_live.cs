using System;
using HalconDotNet;

public partial class HDevelopExport
{
    // Handle defined for all cameras
    public HTuple hv_ExpDefaultWinHandle;

    // Init defined for all cameras
    public void InitHalcon()
    {
    // Default settings used in HDevelop 
    HOperatorSet.SetSystem("width", 512);
    HOperatorSet.SetSystem("height", 512);
    }

    private bool exitloop1;
    public bool Exitloop1
    {
        get { return exitloop1; }
        set { exitloop1 = value; }
    }

    // Main procedure 
    private void action1()
    {


    // Local iconic variables 

    HObject ho_Image=null;

    // Local control variables 

    HTuple hv_AcqHandle = null;
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Image);
    //CAM 4 Diametri
    //HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1, 
    //    "default", -1, "false", "default", "GC3851M_CAM_4", 0, -1, out hv_AcqHandle);
    
    // CAM 1 Robot
    HOperatorSet.OpenFramegrabber("GigEVision", 0, 0, 0, 0, 0, 0, "default", -1, 
        "default", -1, "false", "default", "acA130075gm_CAM", 0, -1, out hv_AcqHandle);



    HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
    //while ((int)(1) != 0)
    while (exitloop1 == false)
    {
        ho_Image.Dispose();
        HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
        //Image Acquisition 01: Do something
        HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
    }
    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
    ho_Image.Dispose();
    HOperatorSet.ClearWindow(hv_ExpDefaultWinHandle);

    }

    public void RunCAM1(HTuple Window)
    {
    hv_ExpDefaultWinHandle = Window;
    action1();
    }

}

