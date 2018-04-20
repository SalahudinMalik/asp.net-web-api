using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.classes
{
    public abstract class clsConvertUnitpublic
    {
        public void NullTrim(ref StringBuilder Ps_Value)
        {
            // ------------------------------------------------------------------------
            //  Desc:
            //    Remove null character from the string value.
            // 
            //  Arguments:
            //    Ps_Value          String to trim NULL characters from
            // 
            //  Modifications:
            //    Version 5.00      20 May 2009   Created by  SHMA (MUZ)
            //                      17 Jun 2009   Reviewed by SHMA (IMR/FK)
            //                      New routine.
            // ------------------------------------------------------------------------
            int li_Pos;
            string value = Ps_Value.ToString();
            if ((value.Trim().Length > 0))
            {
                li_Pos = (value.IndexOf('\0') + 1);
                if ((li_Pos > 0))
                {
                    value = value.Substring(0, (li_Pos - 1)).Trim();
                }

            }
            else
            {
                value = value.Trim();
            }

        }
        // Public MustOverride Function GetTotalUnits(ByVal Pi_PQNo As Integer) As Integer
        public abstract  int GetTotalUnits(int Pi_PQNo);
        // Public MustOverride Function GetConvFactor(ByVal Pi_PQNo As Integer, ByVal Pi_UnitNo As Integer, _
       // ByRef Pd_ConvFactor As Double, ByRef Pd_ConvFactorDivBy As Double, _
       // ByRef Pd_ConvFactorOffSet As Double) As Long
        public abstract long ConvertUnit(int Pi_PQNo , string Ps_FromUnit , ref Double Pd_FromVal  ,string Ps_ToUnit, ref Double Pd_ToVal);
        public abstract long GetUnitName(int Pi_PQNo, int Pi_UnitIndex , ref StringBuilder Ps_UnitDesc);
        public abstract long SearchPQ(string Ps_PQName);
        public abstract long GetConvFactor(int Pi_PQNo, int Pi_UnitNo , ref Double Pd_ConvFactor, ref Double Pd_ConvFactorDivBy , ref Double Pd_ConvFactorOffSet);
    }
}