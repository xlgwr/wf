using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using Workflow.Common;

namespace Workflow.BLL
{
    public class Sys_PO_Schedule
    {
        String cFileName;
        public Sys_PO_Schedule()
        {
            cFileName = "";
        }
        public Sys_PO_Schedule(String cInXML)
        {
            cFileName = cInXML;
        }
        public Sys_PO_Schedule(String cInXML, String cInWoNo)
        {
            cFileName = cInXML;
        }

        public String _cFileName
        {
            get { return cFileName; }
            set { cFileName = value; }
        }
        public void StartParsing()
        {
            String cAction, cSystem, cPONbr, cPORev, cPOType, cOrdDate, cTTLLn, cMG, cCAC, cDO, cSupplier, cOrigSupp, cDefaultPay, cSuppCont, cOrigCont, cBillTo, cShipTo,
                    cPOExRate, cBaseCurr, cPOCurr, cShipTerm, cConnStr, cPayTerm, cBuyerName, cBuyerCode, cPoAmt, cBaseAmt, cUSAmt, cBuyerCmt, cQuery;
            XElement anotherDoc;
            if (cFileName.Length == 0)
                return;
            cConnStr = "Persist Security Info=False;User ID=qims_user;pwd=information;Initial Catalog=WongsOA;Data Source=10.10.11.200;pooling=true";
            SqlCommand cmd;
            cAction = ""; cSystem = ""; cPONbr = ""; cPORev = ""; cPOType = ""; cOrdDate = ""; cTTLLn = ""; cMG = ""; cCAC = ""; cDO = ""; cSupplier = "";
            cOrigSupp = ""; cOrigCont = ""; cBillTo = ""; cShipTo = ""; cPOExRate = ""; cBaseCurr = ""; cPOCurr = ""; cShipTerm = "";
            cPayTerm = ""; cBuyerName = ""; cPoAmt = ""; cBaseAmt = ""; cUSAmt = ""; cBuyerCmt = ""; cBuyerCode = ""; cDefaultPay = ""; cSuppCont = "";
            using (SqlConnection conn = new SqlConnection(cConnStr))
            {
                conn.Open();
                try
                {
                    anotherDoc = XElement.Load(@cFileName);
                }
                catch (Exception) { return; }
                ConvertElementToLower(anotherDoc);
                foreach (var poHeader in anotherDoc.Elements("po_header"))
                {
                    cAction = getElementValue(poHeader, "t_action");
                    cSystem = getElementValue(poHeader, "t_system");
                    cPONbr = getElementValue(poHeader, "po_nbr");
                    cPORev = getElementValue(poHeader, "po_rev");
                    cPOType = getElementValue(poHeader, "type_po");
                    cOrdDate = getElementValue(poHeader, "po_ord_date");
                    cTTLLn = getElementValue(poHeader, "ttl_ln");
                    cMG = getElementValue(poHeader, "model_group");
                    cCAC = getElementValue(poHeader, "cac");
                    cDO = getElementValue(poHeader, "do");
                    cSupplier = getElementValue(poHeader, "supplier");
                    cOrigSupp = getElementValue(poHeader, "orig_supp");
                    cDefaultPay = getElementValue(poHeader, "default_pay");
                    cSuppCont = getElementValue(poHeader, "supp_contact");
                    cOrigCont = getElementValue(poHeader, "original_contact");
                    cBillTo = getElementValue(poHeader, "bill_to");
                    cShipTo = getElementValue(poHeader, "ship_to");
                    cPOExRate = getElementValue(poHeader, "po_ex_rate");
                    cBaseCurr = getElementValue(poHeader, "base_curr");
                    cPOCurr = getElementValue(poHeader, "po_currency");
                    cShipTerm = getElementValue(poHeader, "ship_term");
                    cPayTerm = getElementValue(poHeader, "payment_term");
                    cBuyerName = getElementValue(poHeader, "buyer_name");
                    cBuyerCode = getElementValue(poHeader, "buyer_code");
                    cPoAmt = getElementValue(poHeader, "po_amt");
                    cBaseAmt = getElementValue(poHeader, "base_amt");
                    cUSAmt = getElementValue(poHeader, "us_amt");
                    cBuyerCmt = "";
                    foreach (var cmtBuyer in poHeader.Elements("cmt_buyer"))
                    {
                        cBuyerCmt += cmtBuyer.Value.Replace("\"", "").Replace("\'", "");
                    }
                }

                Console.Write(cBuyerCmt);
                //cQuery = "Insert into [Cus_PO_Mstr]([po_nbr],[po_revision],[po_type],[po_lines],[po_action],[po_location],[po_site], " +
                //     " [po_do],[po_cac],[po_supplier],[po_supplier_orig],[po_buyer_name],[po_buyer_code],[po_curr],[po_curr_base], " +
                //     " [po_bill_to],[po_ship_to],[po_ship_term],[po_amt],[po_amt_base],[po_amt_us],[po_supp_contact],[po_supp_contact_orig], " +
                //     " [po_ex_rate],[po_date_ord],[po_pay_default],[po_payment_term],[po_cmt_internal],[po_cmt_external])" +
                //    " values ('" + cPONbr + "','1','" + cPOType + "','" + cTTLLn + "','" + cAction + "','" + cSystem + "','" + cMG + "'" +
                //    " ,'" + cDO + "','" + cCAC + "','" + cSupplier + "','" + cDefaultPay + "','" + cBuyerName + "','" + cBuyerCode + "','" + cPOCurr + "','" + cPOCurr + "'" +
                //    " ,'" + cBillTo + "','" + cShipTo + "','" + cShipTerm + "','" + cPoAmt + "','" + cBaseAmt + "','" + cUSAmt + "','" + cSuppCont + "','" + cOrigCont + "'" +
                //    " ,'" + cPOExRate + "','" + cOrdDate + "','" + cDefaultPay + "','" + cPayTerm + "','" + cBuyerCmt + "','" + cBuyerCmt + "')";
                cQuery = "insert into test4 values('" + anotherDoc.ToString() + "')";
                cmd = new SqlCommand(cQuery, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message.ToString());
                    ComLogger.Info(true, "1313123");
                    Console.Write(cQuery);
                }

                String cFormPoLine, cPODLine, cPODPart, cPartDesc, cPODQty, cPODQtyRcvd, cSDCReply, cPODDueDate, cPODPurCost,
                    cOrigPOCost, cUSPOCost, cMCWCostUS, cNOOfWarn, cOverPP, cOverMCW, cMFGName, cMFGPart,
                    cPPVend, cPPMRQty, cPPFOB, cPPMfgr, cPPMfgrPart, cPPCurr, cPPCost, cPPCostUS;
                String cPODWarnLine, cFormWarnLine, cWarnLine, cWarnType, cWarnOrig, cWarnCurr, cMFGStat;
                cPODQtyRcvd = "0";
                cFormPoLine = "";
                foreach (var poDetail in anotherDoc.Elements("pod_detail"))
                {
                    ConvertElementToLower(poDetail);
                    foreach (var poDetailLine in poDetail.Elements("pod_detail_line"))
                    {
                        cPODLine = getElementValue(poDetailLine, "pod_line").Trim();
                        cPODPart = getElementValue(poDetailLine, "pod_part");
                        cPartDesc = getElementValue(poDetailLine, "part_description");
                        cPODQty = getElementValue(poDetailLine, "pod_qty_ord");
                        cSDCReply = getElementValue(poDetailLine, "sdc_reply");
                        cPODDueDate = getElementValue(poDetailLine, "pod_due_date");
                        cPODPurCost = getElementValue(poDetailLine, "pod_pur_cost");
                        cOrigPOCost = getElementValue(poDetailLine, "orig_po_cost");
                        cUSPOCost = getElementValue(poDetailLine, "us_po_cost");
                        cMCWCostUS = getElementValue(poDetailLine, "mcw_cost_us");
                        cNOOfWarn = getElementValue(poDetailLine, "no_of_warn");
                        cOverPP = getElementValue(poDetailLine, "over_pp");
                        cOverMCW = getElementValue(poDetailLine, "over_mcw");
                        cMFGName = getElementValue(poDetailLine, "mfg_name");
                        cMFGPart = getElementValue(poDetailLine, "mfg_part");
                        cPPVend = getElementValue(poDetailLine, "pp_vend");
                        cPPMRQty = getElementValue(poDetailLine, "pp_mr_qty");
                        cPPFOB = getElementValue(poDetailLine, "pp_fob");
                        cPPMfgr = getElementValue(poDetailLine, "pp_mfgr");
                        cPPMfgrPart = getElementValue(poDetailLine, "pp_mfgr_part");
                        cPPCurr = getElementValue(poDetailLine, "pp_curr");
                        cPPCost = getElementValue(poDetailLine, "pp_cost");
                        cPPCostUS = getElementValue(poDetailLine, "pp_cost_us");
                        cMFGStat = getElementValue(poDetailLine, "MFGR_St");
                        try
                        {
                            cFormPoLine = Convert.ToDouble(cPODLine).ToString("000");
                        }
                        catch (Exception) { cFormPoLine = cPODLine; }
                        string s = " ,'" + cMFGStat + "','" + cPPVend + "'," + cPPMRQty + ",'" + cPPFOB + "','" + cPPMfgr + "','" + cPPMfgrPart + "','" + cMFGStat + "','" + cPPCurr + "','" + cPPCost + "','" + cPPCostUS + "' ";
                        s = " ,'" + cPPCurr + "','" + cPPCost + "','" + cPPCostUS + "','" + cMFGStat + "','" + cPPCostUS + "','" + cPPCostUS + "','" + cPPCostUS + "','" + cPPCostUS + "','" + cPPCostUS + "') ";
                        cQuery = "Insert into Cus_PO_Det (pod_nbr,pod_line,pod_part,pod_part_desc,pod_ord_qty,pod_rcvd_qty,pod_date_due,pod_cost_pur,pod_cost_po_orig " +
                             " ,pod_cost_mcw_us,pod_cost_us,pod_pp,pod_mcw,pod_mfgr_name,pod_mfgr_part,pod_no_warm,pod_pp_vend,pod_pp_mr_qty,pod_pp_fob,pod_pp_mfgr_name,pod_pp_mfgr_part " +
                             " ,pod_pp_curr,pod_pp_cost,pod_pp_cost_us,pod_mfgr_status,pod_pp_ref_curr,pod_pp_ref_cost,pod_pp_ref_cost_us,pod_pp_lt,pod_ctrl) " +
                             " values ('" + cPONbr + "','" + cFormPoLine + "','" + cPODPart + "','" + cPartDesc + "','" + cPODQty + "','" + cPODQtyRcvd + "','" + cPODDueDate + "','" + cPODPurCost + "','" + cOrigPOCost + "' " +
                             " ,'" + cMCWCostUS + "','" + cUSPOCost + "','" + cPPCost + "','" + cMCWCostUS + "','" + cMFGName + "','" + cMFGPart + "','" + cNOOfWarn + "','" + cPPVend + "','" + cPPMRQty + "','" + cPPFOB + "','" + cPPMfgr + "','" + cPPMfgrPart + "'" +
                             " ,'" + cPPCurr + "','" + cPPCost + "','" + cPPCostUS + "','" + cMFGStat + "','" + cPPCostUS + "','" + cPPCostUS + "','" + cPPCostUS + "','1','" + cPPCostUS + "') ";
                        try
                        {
                            cmd = new SqlCommand(cQuery, conn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message.ToString());
                            Console.Write(cQuery);
                            ComLogger.Info(true, "1313123");
                        }

                        foreach (var poLineWarning in poDetailLine.Elements("warning"))
                        {

                            foreach (var poWarningLine in poLineWarning.Elements("warninglines"))
                            {
                                cPODWarnLine = getElementValue(poWarningLine, "warningpod_line").Trim();
                                cWarnLine = getElementValue(poWarningLine, "warning_line").Trim();
                                cWarnType = getElementValue(poWarningLine, "warning_type");
                                cWarnOrig = getElementValue(poWarningLine, "warning_orig");
                                cWarnCurr = getElementValue(poWarningLine, "warning_current");
                                try
                                {
                                    cFormPoLine = Convert.ToDouble(cPODWarnLine).ToString("000");
                                }
                                catch (Exception) { cFormPoLine = cPODWarnLine; }
                                try
                                {
                                    cFormWarnLine = Convert.ToDouble(cWarnLine).ToString("000");
                                }
                                catch (Exception) { cFormWarnLine = cWarnLine; }
                                cQuery = "Insert Into Cus_PO_Warning([warning_pod_nbr],[warning_pod_line],[warning_pod_revision],[warning_line],[warning_type],[warning_orig],[warning_current]) " +
                                     " values ('" + cPONbr + "','1','" + cFormPoLine + "','" + cFormWarnLine + "','" + cWarnType + "','" + cWarnOrig + "','" + cWarnCurr + "')";
                                try
                                {
                                    cmd = new SqlCommand(cQuery, conn);
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    Console.Write(ex.Message.ToString());
                                    Console.Write(cQuery);
                                    Console.Write("Warning");
                                }
                            }
                        }
                    }
                }
            }
        }
        String getElementValue(XElement cXMLElement, String cElementName)
        {
            try
            {
                foreach (var myElement in cXMLElement.Elements())
                {
                    myElement.Name = myElement.Name.ToString().ToLower().Replace("\"", "").Replace("\'", "");
                }
                return cXMLElement.Element(cElementName.ToLower()).Value.Replace("\"", "").Replace("\'", "");
            }
            catch (Exception) { return ""; }
        }
        void ConvertElementToLower(XElement cXMLElement)
        {
            try
            {
                foreach (var myElement in cXMLElement.Elements())
                {
                    myElement.Name = myElement.Name.ToString().ToLower();
                }
            }
            catch (Exception) { }
        }
    }
}
