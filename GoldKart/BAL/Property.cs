using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;

namespace BMSAddressChange.BLL
{
    public abstract class Property : Common
    {
        #region Properties Beneficiary
        public int Scoresession;
        private int _distcode; public int DistrictCode { get { return _distcode; } set { _distcode = value; } }
        private int _talukcode; public int TalukCode { get { return _talukcode; } set { _talukcode = value; } }
        private string _hoblicode; public string HobliCode { get { return _hoblicode; } set { _hoblicode = value; } }
        private byte _vacode; public byte VACode { get { return _vacode; } set { _vacode = value; } }
        private byte _departmentcode; public byte DepartmentCode { get { return _departmentcode; } set { _departmentcode = value; } }
        private int _villagecode; public int VillageTownCode { get { return _villagecode; } set { _villagecode = value; } }
        private string _beneficiaryId; public string BeneficiaryID { get { return _beneficiaryId; } set { _beneficiaryId = value; } }
        private string _firstnameE; public string FirstNameE { get { return _firstnameE; } set { _firstnameE = value; } }
        private string _srcName; public string SourceName { get { return _srcName; } set { _srcName = value; } }
        private string _middlenameE; public string MiddleNameE { get { return _middlenameE; } set { _middlenameE = value; } }
        private string _lastnameE; public string LastNameE { get { return _lastnameE; } set { _lastnameE = value; } }
        private string _firstnameK; public string FirstNameK { get { return _firstnameK; } set { _firstnameK = value; } }
        private string _middlenameK; public string MiddleNameK { get { return _middlenameK; } set { _middlenameK = value; } }
        private string _lastNameK; public string LastNameK { get { return _lastNameK; } set { _lastNameK = value; } }
        private string _fathername; public string FatherName { get { return _fathername; } set { _fathername = value; } }
        private string _husbandname; public string Husbandname { get { return _husbandname; } set { _husbandname = value; } }
        private string _hfnamek; public string HusbandFNameK { get { return _hfnamek; } set { _hfnamek = value; } }
        private string _hmnamek; public string HusbandMNameK { get { return _hmnamek; } set { _hmnamek = value; } }
        private string _hlnamek; public string HusbandLNameK { get { return _hlnamek; } set { _hlnamek = value; } }
        private string _hfnameE; public string HusbandFNameE { get { return _hfnameE; } set { _hfnameE = value; } }
        private string _hmnameE; public string HusbandMNameE { get { return _hmnameE; } set { _hmnameE = value; } }
        private string _hlnameE; public string HusbandLNameE { get { return _hlnameE; } set { _hlnameE = value; } }
        private string _badd1k; public string BAddress1K { get { return _badd1k; } set { _badd1k = value; } }
        private string _badd2k; public string BAddress2K { get { return _badd2k; } set { _badd2k = value; } }
        private string _badd3K; public string BAddress3K { get { return _badd3K; } set { _badd3K = value; } }
        private string _badd1E; public string BAddress1E { get { return _badd1E; } set { _badd1E = value; } }
        private string _badd2E; public string BAddress2E { get { return _badd2E; } set { _badd2E = value; } }
        private string _badd3E; public string BAddress3E { get { return _badd3E; } set { _badd3E = value; } }
        private byte? _bincom; public byte? BinComCode { get { return _bincom; } set { _bincom = value; } }
        private char _Consent; public char Consent { get { return _Consent; } set { _Consent = value; } }
        private string _OpUID; public string OpUID { get { return _OpUID; } set { _OpUID = value; } }

        private string _TransactionID; public string TransactionID { get { return _TransactionID; } set { _TransactionID = value; } }

        private string _fromWhichTable; public string fromWhichTable { get { return _fromWhichTable; } set { _fromWhichTable = value; } }


        private int? _cast; public int? CastCode { get { return _cast; } set { _cast = value; } }
        private byte? _religion; public byte? ReligionCode { get { return _religion; } set { _religion = value; } }
        private byte? _Bage; public byte? Age { get { return _Bage; } set { _Bage = value; } }
        private DateTime? _Bdob; public DateTime? DateOfBirth { get { return _Bdob; } set { _Bdob = value; } }
        private string _strDob; public string StrDOB { get { return _strDob; } set { _strDob = value; } }
        private int? _pincode; public int? PinCode { get { return _pincode; } set { _pincode = value; } }
        private string _bsex; public string SexCode { get { return _bsex; } set { _bsex = value; } }
        private byte? _rescacode; public byte? ReserveCatCode { get { return _rescacode; } set { _rescacode = value; } }
        private DateTime? _sorderdate; public DateTime? SOrderDate { get { return _sorderdate; } set { _sorderdate = value; } }
        private string _sorderno; public string SOrderNo { get { return _sorderno; } set { _sorderno = value; } }
        //private string _fingerreport1; public string FingerReport1 { get { return _fingerreport1; } set { _fingerreport1 = value; } }
        //private string _fingerreport2; public string FingerReport2 { get { return _fingerreport2; } set { _fingerreport2 = value; } }
        private string _identifimark1; public string IdentificationMarks1 { get { return _identifimark1; } set { _identifimark1 = value; } }
        private string _identifimark2; public string IdentificationMarks2 { get { return _identifimark2; } set { _identifimark2 = value; } }
        private string _rationcardno; public string RationCardNo { get { return _rationcardno; } set { _rationcardno = value; } }
        private string _epiccardno; public string EpicCardNo { get { return _epiccardno; } set { _epiccardno = value; } }
        private DateTime? _startdate; public DateTime? StartDate { get { return _startdate; } set { _startdate = value; } }
        private int? _pensionamt; public int? PensionAmt { get { return _pensionamt; } set { _pensionamt = value; } }
        private string _institutename; public string InstituteName { get { return _institutename; } set { _institutename = value; } }
        private string _instAdd1; public string InstituteAdd1 { get { return _instAdd1; } set { _instAdd1 = value; } }
        private string _instAdd; public string InstituteAdd2 { get { return _instAdd; } set { _instAdd = value; } }
        private string _instAdd3; public string InstituteAdd3 { get { return _instAdd3; } set { _instAdd3 = value; } }
        private int? _instPin; public int? InstitutePin { get { return _instPin; } set { _instPin = value; } }
        private string _status; public string Status { get { return _status; } set { _status = value; } }
        private byte? _disabilitytype; public byte? DisabilityType { get { return _disabilitytype; } set { _disabilitytype = value; } }
        private byte? _disabiltyper; public byte? DisabililtyPer { get { return _disabiltyper; } set { _disabiltyper = value; } }
        private string _doctorname; public string DoctorName { get { return _doctorname; } set { _doctorname = value; } }
        private string _doctorregno; public string DoctorRegNo { get { return _doctorregno; } set { _doctorregno = value; } }
        private DateTime? _deathdate; public DateTime? DeathDate { get { return _deathdate; } set { _deathdate = value; } }
        private byte? _deathreason; public byte? DeathReason { get { return _deathreason; } set { _deathreason = value; } }
        private int? _deasedage; public int? DeasedAge { get { return _deasedage; } set { _deasedage = value; } }
        private String _gpcode; public String GPCode { get { return _gpcode; } set { _gpcode = value; } }
        private string _jobcardno; public string JobCardNo { get { return _jobcardno; } set { _jobcardno = value; } }
        private string _ruralurban; public string RuralUrban { get { return _ruralurban; } set { _ruralurban = value; } }
        private string _schemecode; public string SchemeCode { get { return _schemecode; } set { _schemecode = value; } }
        private DateTime? _susDate; public DateTime? SuspensionDate { get { return _susDate; } set { _susDate = value; } }
        private DateTime? _contdate; public DateTime? ContinuationDate { get { return _contdate; } set { _contdate = value; } }
        private int _arrAmt; public int ArrearesAmount { get { return _arrAmt; } set { _arrAmt = value; } }
        private int mymonth; public int MyMonth { get { return mymonth; } set { mymonth = value; } }
        private int myyear; public int MyYear { get { return myyear; } set { myyear = value; } }
        private DateTime _fromdate; public DateTime FromDate { get { return _fromdate; } set { _fromdate = value; } }
        private DateTime _todate; public DateTime ToDate { get { return _todate; } set { _todate = value; } }
        private string _file2bank; public string File2Bank { get { return _file2bank; } set { _file2bank = value; } }
        private string _file2bankname; public string File2BankName { get { return _file2bankname; } set { _file2bankname = value; } }
        private string _file2sdc; public string File2SDC { get { return _file2sdc; } set { _file2sdc = value; } }
        private DateTime? _file2banksentdate; public DateTime? File2BankSentDate { get { return _file2banksentdate; } set { _file2banksentdate = value; } }
        private string _bankconfirmation; public string BankConfirmation { get { return _bankconfirmation; } set { _bankconfirmation = value; } }
        private DateTime? _bankconfirmationdate; public DateTime? BankConfirmationDate { get { return _bankconfirmationdate; } set { _bankconfirmationdate = value; } }
        private string _filefrombank; public string FileFromBank { get { return _filefrombank; } set { _filefrombank = value; } }
        private string _filefrombankname; public string FilefromBankName { get { return _filefrombankname; } set { _filefrombankname = value; } }
        private DateTime? _filefrombanksentdate; public DateTime? FilefromBankSentDate { get { return _filefrombanksentdate; } set { _filefrombanksentdate = value; } }
        private string _tahconfirmation; public string TahsilConfirmation { get { return _tahconfirmation; } set { _tahconfirmation = value; } }
        private DateTime? _tahsilconfirmationdate; public DateTime? TahsilConfirmationDate { get { return _tahsilconfirmationdate; } set { _tahsilconfirmationdate = value; } }
        private string _bankcode; public string BankCode { get { return _bankcode; } set { _bankcode = value; } }
        private string _bankbranchcode; public string BankBranchCode { get { return _bankbranchcode; } set { _bankbranchcode = value; } }
        private string _accountNo; public string AccountNo { get { return _accountNo; } set { _accountNo = value; } }
        private DateTime? _acccreateddate; public DateTime? AccCreatedDate { get { return _acccreateddate; } set { _acccreateddate = value; } }
        private string _bankName; public string BankName { get { return _bankName; } set { _bankName = value; } }
        private string _schemename; public string SchemeName { get { return _schemename; } set { _schemename = value; } }
        private int _totalBen; public int TotalBen { get { return _totalBen; } set { _totalBen = value; } }
        private double _toatlAmt; public double TotalAmt { get { return _toatlAmt; } set { _toatlAmt = value; } }
        private string _chequeno; public string ChequeNo { get { return _chequeno; } set { _chequeno = value; } }
        private DateTime _chequedate; public DateTime ChequeDate { get { return _chequedate; } set { _chequedate = value; } }
        private string _billtype; public string BillType { get { return _billtype; } set { _billtype = value; } }
        private string _name; public string Name { get { return _name; } set { _name = value; } }
        private string _contenttype; public string ContentType { get { return _contenttype; } set { _contenttype = value; } }
        private string _data; public string Data { get { return _data; } set { _data = value; } }
        private string _suspensionreason; public string SuspensionReason { get { return _suspensionreason; } set { _suspensionreason = value; } }
        private int _towncode; public int TownCode { get { return _towncode; } set { _towncode = value; } }
        private int _habitationcode; public int HabitationCode { get { return _habitationcode; } set { _habitationcode = value; } }
        private int _wardcode; public int WardCode { get { return _wardcode; } set { _wardcode = value; } }
        private byte _category; public byte Category { get { return _category; } set { _category = value; } }
        private byte _subcat; public byte SubCategory { get { return _subcat; } set { _subcat = value; } }
        private byte _facilitycode; public byte FaciltyCode { get { return _facilitycode; } set { _facilitycode = value; } }
        private string _reqid; public string RDSReqID { get { return _reqid; } set { _reqid = value; } }
        private string _susreason; public string SusReason { get { return _susreason; } set { _susreason = value; } }
        private DateTime? _updateddate; public DateTime? UpdatedDate { get { return _updateddate; } set { _updateddate = value; } }
        private string _apptah; public string ApproveByTah { get { return _apptah; } set { _apptah = value; } }
        private string _smartcard; public string SmartCardNo { get { return _smartcard; } set { _smartcard = value; } }
        private DateTime? _bdeathdate; public DateTime? BDeathDate { get { return _bdeathdate; } set { _bdeathdate = value; } }
        private int _designationcode; public int DesiCode { get { return _designationcode; } set { _designationcode = value; } }
        private String _benidlist; public String BenIDList { get { return _benidlist; } set { _benidlist = value; } }
        private int _frmmnt; public int FromMonth { get { return _frmmnt; } set { _frmmnt = value; } }
        private int _toMnt; public int ToMonth { get { return _toMnt; } set { _toMnt = value; } }
        private string _legacydata; public string LegacyData { get { return _legacydata; } set { _legacydata = value; } }
        private int _obj; public int obj { get { return _obj; } set { _obj = value; } }
        [BrowsableAttribute(false)]
        private string _viewsateuserkey; public string ViewStateUserKey { get { return _viewsateuserkey; } set { _viewsateuserkey = value; } }
        private string _loginid; public string LoginID { get { return _loginid; } set { _loginid = value; } }
        private string _password; public string Password { get { return _password; } set { _password = value; } }
        private string _oldpassword; public string OldPassword { get { return _oldpassword; } set { _oldpassword = value; } }
        private string _dcsn; public string DCSN { get { return _dcsn; } set { _dcsn = value; } }
        private string _dcsname; public string DCSName { get { return _dcsname; } set { _dcsname = value; } }
        private string _idc; public string IDC { get { return _idc; } set { _idc = value; } }
        private string _usercreater; public string UserCreater { get { return _usercreater; } set { _usercreater = value; } }
        private byte _rolecode; public byte RoleCode { get { return _rolecode; } set { _rolecode = value; } }
        private string _actionmade; public string Actionmade { get { return _actionmade; } set { _actionmade = value; } }
        private string _Address; public string Address { get { return _Address; } set { _Address = value; } }
        private string _dob; public string DOB { get { return _dob; } set { _dob = value; } }
        private string _doj; public string DOJ { get { return _doj; } set { _doj = value; } }
        private string _dor; public string DOR { get { return _dor; } set { _dor = value; } }
        private string _remarks; public string Remarks { get { return _remarks; } set { _remarks = value; } }
        private string _UID; public string UID { get { return _UID; } set { _UID = value; } }
        private string _MobileNo; public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }
        private string _EmailID; public string EmailID { get { return _EmailID; } set { _EmailID = value; } }
        private string _ModifiedByEA; public string ModifiedByEA { get { return _ModifiedByEA; } set { _ModifiedByEA = value; } }
        private string _Enroled; public string Enroled { get { return _Enroled; } set { _Enroled = value; } }
        private string _SusStatus; public string SusStatus { get { return _SusStatus; } set { _SusStatus = value; } }

        private byte? _Oage; public byte? OldAge { get { return _Oage; } set { _Oage = value; } }
        private string _Odob; public string OldDOB { get { return _Odob; } set { _Odob = value; } }
        private byte? _Orescacode; public byte? OldReserveCatCode { get { return _Orescacode; } set { _Orescacode = value; } }
        private int? _Ocast; public int? OldCastCode { get { return _Ocast; } set { _Ocast = value; } }
        private string _Flag; public string Flag { get { return _Flag; } set { _Flag = value; } }
        private string _Flag1; public string Flag1 { get { return _Flag1; } set { _Flag1 = value; } }
        private string _TransID; public string TransID { get { return _TransID; } set { _TransID = value; } }

        private DateTime? _printeddate; public DateTime? PrintedDate { get { return _printeddate; } set { _printeddate = value; } }
        private string _slno; public string SLNo { get { return _slno; } set { _slno = value; } }
        private int toyear; public int ToYear { get { return toyear; } set { toyear = value; } }
        private int fromyear; public int FromYear { get { return fromyear; } set { fromyear = value; } }

        private string _machineId; public string MachineId { get { return _machineId; } set { _machineId = value; } }
        private DateTime? _logintime; public DateTime? Logintime { get { return _logintime; } set { _logintime = value; } }
        private DateTime? _logouttime; public DateTime? Logouttime { get { return _logouttime; } set { _logouttime = value; } }
        private int _srlNo; public int SrlNo { get { return _srlNo; } set { _srlNo = value; } }
        private string _LoginStatus; public string LoginStatus { get { return _LoginStatus; } set { _LoginStatus = value; } }
        private string _reason; public string Reason { get { return _reason; } set { _reason = value; } }

        private string _ipAddress; public string IpAddress { get { return _ipAddress; } set { _ipAddress = value; } }
        private DateTime? _currentTime; public DateTime? CurrentTime { get { return _currentTime; } set { _currentTime = value; } }
        private int _noofDays; public int NoofDays { get { return _noofDays; } set { _noofDays = value; } }
        private string _subschemecode; public string Subschemecode { get { return _subschemecode; } set { _subschemecode = value; } }

        private string _schemecodeOld; public string SchemecodeOld { get { return _schemecodeOld; } set { _schemecodeOld = value; } }
        private string newSchemeCode; public string NewSchemeCode { get { return newSchemeCode; } set { newSchemeCode = value; } }

        private string _GuardianNameE; public string GuardianNameE { get { return _GuardianNameE; } set { _GuardianNameE = value; } }
        private string _GuardianNameK; public string GuardianNameK { get { return _GuardianNameK; } set { _GuardianNameK = value; } }
        private int _GuardianTitleE; public int  GuardianTitleE { get { return _GuardianTitleE; } set { _GuardianTitleE = value; } }

        //dSign
        private string _hash; public string Hash { get { return _hash; } set { _hash = value; } }
        private string _subjectname; public string SubjectName { get { return _subjectname; } set { _subjectname = value; } }
        private string _issuername; public string IssuerName { get { return _issuername; } set { _issuername = value; } }
        private string _serialnumber; public string SerialNumber { get { return _serialnumber; } set { _serialnumber = value; } }
        //dSign

        private string _rdsRequestId; public string RDS_Request_Id { get { return _rdsRequestId; } set { _rdsRequestId = value; } }

        //09/09/2014
        private string _treasuryid; public string TreasuryId { get { return _treasuryid; } set { _treasuryid = value; } }
        private string _ppoid; public string PPOId { get { return _ppoid; } set { _ppoid = value; } }

        //15/10/2014 Added for TB Reset Module
        private string _tbresetreason; public string TBResetReason { get { return _tbresetreason; } set { _tbresetreason = value; } }
        private int _tbresetresult; public int TBResetResult { get { return _tbresetresult; } set { _tbresetresult = value; } }

        //15/11/2014 Added during Aadhaar report generation module.
        private DataTable _dt; public DataTable DT { get { return _dt; } set { _dt = value; } }

        //Code Added For BMS Address Change
        private byte[] _uploadFile; public byte[] UploadFile { get { return _uploadFile; } set { _uploadFile = value; } }
        private DataTable _dataTable; public DataTable TableData { get { return _dataTable; } set { _dataTable = value; } }
        private char _paymentMode; public char PaymentMode { get { return _paymentMode; } set { _paymentMode = value; } }
        private string _ifscCode; public string IfscCode { get { return _ifscCode; } set { _ifscCode = value; } }
        private string _micrNo; public string MicrNo { get { return _micrNo; } set { _micrNo = value; } }
        private string _PoName; public string POName { get { return _PoName; } set { _PoName = value; } }
        private string _PoPinCode; public string POPinCode { get { return _PoPinCode; } set { _PoPinCode = value; } }
        private char _oldStatus; public char OldStatus { get { return _oldStatus; } set { _oldStatus = value; } }
        private char _newStatus; public char NewStatus { get { return _newStatus; } set { _newStatus = value; } }
        private DateTime _changeDate; public DateTime ChangeDate { get { return _changeDate; } set { _changeDate = value; } }
        private string _hobliTown; public string HobliTownCode { get { return _hobliTown; } set { _hobliTown = value; } }
        //End Of Code
        
        //For Winston, Biometric
        //For Senthil Reports Page
  
        // Reports
        private string _StrFromDate; public string StrFromDate { get { return _StrFromDate; } set { _StrFromDate = value; } }
        private string _StrToDate; public string StrToDate { get { return _StrToDate; } set { _StrToDate = value; } }
        private string _StrSumDate; public string StrSumDate { get { return _StrSumDate; } set { _StrSumDate = value; } }
        private string _InteractionType; public string InteractionType { get { return _InteractionType; } set { _InteractionType = value; } }
        private int _NKDistrictCode; public int NKDistrictCode { get { return _NKDistrictCode; } set { _NKDistrictCode = value; } }
        private int _NKTalukCode; public int NKTalukCode { get { return _NKTalukCode; } set { _NKTalukCode = value; } }
        private char _MonthStats; public char MonthStats { get { return _MonthStats; } set { _MonthStats = value; } }
        private string _firstpage; public string firstpage { get { return _firstpage; } set { _firstpage = value; } }
        private string _authmode; public string authmode { get { return _authmode; } set { _authmode = value; } }
        private string _aashaarseeded; public string aashaarseeded { get { return _aashaarseeded; } set { _aashaarseeded = value; } }
        private string _AadharKRDH; public string AadharKRDH { get { return _AadharKRDH; } set { _AadharKRDH = value; } }

        private char _SpecialTaluk; public char SpecialTaluk { get { return _SpecialTaluk; } set { _SpecialTaluk = value; } }

        private char _BM_Ben_Status; public char BM_Ben_Status { get { return _BM_Ben_Status; } set { _BM_Ben_Status = value; } }
        private char _BM_Disbursement_Mode; public char BM_Disbursement_Mode { get { return _BM_Disbursement_Mode; } set { _BM_Disbursement_Mode = value; } }
        private char _BM_Gender; public char BM_Gender { get { return _BM_Gender; } set { _BM_Gender = value; } }
     
        //For EDP 
        private int? _OrderNo; public int? OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }

        private string _EDPFLAG; public string EDPFLAG { get { return _EDPFLAG; } set { _EDPFLAG = value; } }

        #endregion
    }
}