using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.classes 
{
    public class clsDLLBasedConv : clsConvertUnitpublic
    {
        [DllImport("CU64.DLL")]
        private static extern long CUConvertUnit(int x1, string s1, ref double FromVal, string s3, ref double ToVal);

        [DllImport("CU64.DLL")]
        private static extern long CUGetPQName(int x1, StringBuilder s1);

        [DllImport("CU64.DLL")]
        private static extern int CUGetTotalPQs();

        [DllImport("CU64.DLL")]
        private static extern int CUGetTotalUnits(int x1);

        [DllImport("CU64.DLL")]
        private static extern int CUGetUnitName(int x1, int x2, StringBuilder s1);

        [DllImport("CU64.DLL")]
        private static extern long CUSearchUnit(string s1);

        [DllImport("CU64.DLL")]
        private static extern long CUSearchPQ(string s1);

        [DllImport("CU64.DLL")]
        private static extern long CUGetConvFactor(int x1, int x2, ref double ConvFactor, ref double ConvFactorDivBy, ref double ConvFactorOffSet);

        [DllImport("CU64.DLL")]
        private static extern int CU32Version();

        private int mi_MAXPQS;
        const int CU_Angle = 1;
        const int CU_Area = 2;
        const int CU_Bond_Work_Index = 3;
        const int CU_Calorific_Value_Mass = 4;
        const int CU_Calorific_Value_Vol = 5;
        const int CU_Conductivity = 6;
        const int CU_Density = 7;
        const int CU_Diffusivity = 8;
        const int CU_Dipole_Moment = 9;
        const int CU_Energy = 10;
        const int CU_Enthalpy = 11;
        const int CU_Entrainment = 12;
        const int CU_Entropy = 13;
        const int CU_Flowrate_Enthalpy = 14;
        const int CU_Flowrate_Mass = 15;
        const int CU_Flowrate_Volume = 16;
        const int CU_Force = 17;
        const int CU_Fouling_Factor = 18;
        const int CU_Frequency = 19;
        const int CU_Head = 20;
        const int CU_Heat_Flux = 21;
        const int CU_Heat_Transfer_Coeff = 22;
        const int CU_Length = 23;
        const int CU_Mass_Trans_Coef = 24;
        const int CU_Mass_Per_Unit_Area = 25;
        const int CU_Mass_Per_Unit_Length = 26;
        const int CU_Mass = 27;
        const int CU_Molar_Flowrate = 28;
        const int CU_Molecular_Weight = 29;
        const int CU_Momentum_Flux = 30;
        const int CU_Power_Duty = 31;
        const int CU_Pressure = 32;
        const int CU_Spec_Heat_Cap_Mass = 33;
        const int CU_Spec_Heat_Cap_Vol = 34;
        const int CU_Specific_Area = 35;
        const int CU_Specific_Volume = 36;
        const int CU_Surface_Tension = 37;
        const int CU_Temperature_Difference = 38;
        const int CU_Temperature = 39;
        const int CU_Thermal_Cond = 40;
        const int CU_Time = 41;
        const int CU_Velocity_Linear = 42;
        const int CU_Velocity_Rotational = 43;
        const int CU_Viscosity_Dynamic = 44;
        const int CU_Viscosity_Kinematic = 45;
        const int CU_Volume_Flowrate_Area = 46;
        const int CU_Volume_Flowrate_Length = 47;
        const int CU_Volume = 48;
        const int CU_One_Absolute_Temp = 49;
        const int CU_One_Length = 50;
        const int CU_One_Time = 51;
        const int CU_One_Area = 52;
        const int CU_Acceleration = 53;
        const int CU_Coef_of_Expansion = 54;
        const int CU_Heat_Release_Rate = 55;
        const int CU_Mass_Flux = 56;
        const int CU_Mass_Release_Rate = 57;
        const int CU_Mass_Transfer_Coef_Partial_Press = 58;
        const int CU_Angular_Momentum = 59;
        const int CU_Linear_Momentum = 60;
        const int CU_Moment_of_Inertia = 61;
        const int CU_Specific_Area_Mass = 62;
        const int CU_Volumetric_Wetting_Rate = 63;
        const int CU_FS_Factor = 64;
        const int CU_Pressure_Gradient = 65;
        const int CU_Angular_Acceleration = 66;
        const int CU_Number = 67;
        const int CU_GOR = 68;
        const int CU_Valve_Flow_Coefficient = 69;
        const int CU_Inflow_Performance = 70;
        public clsDLLBasedConv()
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Initialise total number of physical quantities.
            // 
            //  Arguments:
            //    None.
            // 
            //  Modifications:
            //       Version 5.04      20 Mar 2014  Created  by SHMA (HR)
            //                      20 Mar 2014  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            try
            {
                // 
                //  Get Total number of Physical Quantities from DLL
                // 
                mi_MAXPQS = GetTotalPQs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(("Unexpected error encountered in  "
                                + (MethodBase.GetCurrentMethod().Name + (". Error details are as follows:"
                                + (Environment.NewLine
                                + (ex.Message
                                + (Environment.NewLine
                                + (Environment.NewLine + "The application will be terminated."))))))));
            }
        }
        public int GetTotalPQs()
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns the total number of PQs in dll.
            // 
            //  Arguments:
            //    None
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUGetTotalPQs();
        }
        public override long GetUnitName(int Pi_PQNo, int Pi_UnitIndex, ref StringBuilder Ps_UnitDesc)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns the unit name at specific index of PQ.
            // 
            //  Arguments:
            //       Pi_PQNo           Physical qty no.
            //    Pi_UnitIndex      Unit index in PQ.
            //    Ps_UnitDesc       Unit Name.
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUGetUnitName(Pi_PQNo, Pi_UnitIndex, Ps_UnitDesc);
        }
       
        public override int GetTotalUnits(int Pi_PQNo)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns the total number of units in the physical qty.
            // 
            //  Arguments:
            //       Pi_PQNo           Physical qty no.
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUGetTotalUnits(Pi_PQNo);
        }
        public long SearchUnit(string Ps_UnitDesc)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Searchs the units array to see whether a unit exists or not.
            //    Returns a number if the unit found and returns BAD_NUMBER
            //    if not found.
            // 
            //  Arguments:
            //    Ps_UnitDesc       Unit Name.
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUSearchUnit(Ps_UnitDesc);
        }
        public override long SearchPQ(string Ps_PQName)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns the PQNo. of physical qty.
            // 
            //  Arguments:
            //    Ps_PQName         Physical qty no.
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUSearchPQ(Ps_PQName);
        }
        public long GetPQName(int Pi_PQNo, ref StringBuilder Ps_PQName)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns the PQName against the specified PQNo.
            // 
            //  Arguments:
            //       Pi_PQNo           Physical qty no.
            //    Ps_PQName         Physcal qty name.
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUGetPQName(Pi_PQNo, Ps_PQName);
        }
        public override long ConvertUnit(int Pi_PQNo, string Ps_FromUnit, ref double Pd_FromVal, string Ps_ToUnit, ref double Pd_ToVal)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Converts a given number from one unit to another.
            // 
            //  Arguments:
            //    Pi_PQNo           Physical qty no.
            //       Ps_FromUnit       Unit to be converted
            //    Pd_FromVal        Value to be converted
            //    Ps_ToUnit         Unit to be converted into
            //    Pd_ToVal          Variable to hold coverted value
            // 
            //  Modifications:
            //       Version 5.0       29 Oct 2009  Created  by SHMA (HR)
            //                      19 Nov 2009  Reviewed by SHMA (FK)
            //                      New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUConvertUnit(Pi_PQNo, Ps_FromUnit, ref Pd_FromVal, Ps_ToUnit,ref Pd_ToVal);
        }
        public override long GetConvFactor(int Pi_PQNo, int Pi_UnitNo, ref double Pd_ConvFactor, ref double Pd_ConvFactorDivBy, ref double Pd_ConvFactorOffSet)
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns the conversion factors for the unit.
            // 
            //  Arguments:
            //       Pi_PQNo               PQNo. of the physical qty.
            //    Pi_UnitNo             Unit index of PQ unit
            //    Pd_ConvFactor         conv. factor for the unit
            //    Pd_ConvFactorDivBy    conv. factor div. for the unit
            //    Pd_ConvFactorOffSet   conv. factor offset for the unit
            // 
            //  Modifications:
            //       Version 5.0           29 Oct 2009  Created  by SHMA (HR)
            //                          19 Nov 2009  Reviewed by SHMA (FK)
            //                          New routine
            // ---------------------------------------------------------------
            // 
            //  Call the function of CU64.DLL
            // 
            return CUGetConvFactor(Pi_PQNo, Pi_UnitNo, ref Pd_ConvFactor, ref Pd_ConvFactorDivBy, ref Pd_ConvFactorOffSet);
        }

        public string GetCU32Version()
        {
            // --------------------------------------------------------------
            //  Desc:
            //       Returns CU64.DLL version no. being displayed on About dialog
            // 
            //  Arguments:
            //       None.
            // 
            //  Modifications:
            //       Version 5.02          26 Apr 2011  Created  by SHMA (HR)
            //                          27 Apr 2011  Reviewed by SHMA (FK)
            //                          New routine
            // ---------------------------------------------------------------
            string ls_Version = "undefined";
            try
            {
                // 
                //  Call the function of CU64.DLL to get its version number
                // 
                ls_Version = CU32Version().ToString().Trim();
                // 
                //  Format the version string as CU64.DLL returns long
                //  type which contains Major version as decimal part
                //  and mantissa represents minor version no.
                //
                // ls_Version = ls_Version.Chars(0) & "." & ls_Version.Substring(1, ls_Version.Length - 1)
                ls_Version = (ls_Version.Substring(0, 1) + ("." + ls_Version.Substring(1, (ls_Version.Length - 1))));
            }
            catch (System.Exception ex)
            {
               
                    return ls_Version;
               

            }
            return ls_Version;

        }
        public List<PQModel> getAllPQ()
        {
            List<PQModel> sList = new List<PQModel>();

            int li_TotalPQ;
            int li_Ctr;
            StringBuilder ls_PQName;
            // 
            //  Get physical qty names from CU32 dll and update Parameter combo box.
            // 
            try
            {
                li_TotalPQ = this.GetTotalPQs();
                for (li_Ctr = 1; (li_Ctr <= li_TotalPQ); li_Ctr++)
                {
                    PQModel pq = new PQModel();
                    ls_PQName =  new StringBuilder(100);
                    this.GetPQName(li_Ctr, ref ls_PQName).ToString();
                    this.NullTrim(ref ls_PQName);
                    // 
                    //  Store PQ Name along with its PQNo.
                    // 
                    //gs_PQName((li_Ctr - 1), 0) = ls_PQName;
                    // gs_PQName((li_Ctr - 1), 1) = li_Ctr;
                    // 
                    //  Add PQ Name into Parameter combo box
                    // 
                    //sList.Add(ls_PQName);
                    // sList.Add(ls_PQName.ToString());
                    pq.pqId = li_Ctr;
                    pq.pqData = ls_PQName.ToString();
                    sList.Add(pq);
                }

                // 
                //  Get physical qty names of formula base
                //  quantities and update Parameter combo box.
                // 
                /* for (li_Ctr = 1; (li_Ctr
                             <= (ms_FormulaBased_PQ.Length - 1)); li_Ctr++)
                 {
                     cboParameter.Items.Add(clsFormulaBasedConv.ms_FormulaBased_PQ(li_Ctr));
                 } */
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
           
            return sList;
        }
        public List<string> getAllUnits(int pqNo)
        {
            int totalUnit = this.GetTotalUnits(pqNo);
            List<string> unitList = new List<string>();
            StringBuilder unit;
            for (int i = 0; i < totalUnit; i++)
            {
                unit = new StringBuilder(100);
                this.GetUnitName(pqNo, i, ref unit);
                this.NullTrim(ref unit);
                unitList.Add(unit.ToString());

            }
            return unitList;
        }
        public string CalConversion(int pqNo , string fromUnit , ref Double fromVal , string toUnit )
        {
            long retValue;
            Double toVal = 0.0;
            retValue = this.ConvertUnit(pqNo, fromUnit, ref fromVal, toUnit, ref toVal);
            this.PerformFormating(toVal);
            return toVal.ToString();

        }
        private void PerformFormating(double Pd_Value)
        {
            // --------------------------------------------------------------
            //  Desc:
            //    Performs Result formatting.
            // 
            //  Arguments:
            //    Pd_Value          Value to be formatted
            //   
            // 
            //  Modifications:
            //    Version 5.0       20 May 2009   Created  by SHMA(MUZ)
            //                      17 Jun 2009   Reviewed by SHMA(IMR/FK)
            //                      New routine
            // ---------------------------------------------------------------
            string ls_ResultFormat;
            string ls_IntegerFormat;
            double ld_Result;
            ld_Result = Math.Abs(Pd_Value);
            if ((ld_Result > 100000))
            {
                ls_ResultFormat = "0.0E+00";
                ls_IntegerFormat = "0.0E+00";
            }
            else if ((ld_Result > 1000))
            {
                ls_ResultFormat = "0.0#";
                ls_IntegerFormat = "0";
            }
            else if ((ld_Result > 100))
            {
                ls_ResultFormat = "0.0##";
                ls_IntegerFormat = "0";
            }
            else if ((ld_Result > 10))
            {
                ls_ResultFormat = "0.0###";
                ls_IntegerFormat = "0";
            }
            else if ((ld_Result > 0.01))
            {
                ls_ResultFormat = "0.0####";
                ls_IntegerFormat = "0";
            }
            else
            {
                ls_ResultFormat = "0.0####E+00";
                ls_IntegerFormat = "0.0####E+00";
            }

            // 
            //  Format result.
            /*
            if ((Convert.ToString(Int(ld_Result)) == Convert.ToString(ld_Result)))
            {
                txtResult.Text = Format(Pd_Value, ls_IntegerFormat);
            }
            else
            {
                txtResult.Text = Format(Pd_Value, ls_ResultFormat);
            }
            */
            // 
            //  Format for Input value Field
            // 
            // 
            // ld_InputValue = CVal(txtConvVal.Text)  FK123
            // If CStr(Int(ld_InputValue)) = CStr(ld_InputValue) And InStr(UCase(ld_InputValue), "E") < 1 Then
            //   String.Format(txtConvVal.Text, "0")
            // Else
            //   String.Format(txtConvVal.Text, "0.0000000000E+00")
            // End If
        }
    }
}