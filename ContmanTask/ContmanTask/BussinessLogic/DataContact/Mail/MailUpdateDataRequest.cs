﻿namespace ContmanTask.BussinessLogic.DataContact.Mail
{
    public class MailUpdateDataRequest
    {
        public string Mail { get; set; }
        public string NewMail { get; set; }
        public string NewAccountName { get; set; }
        public int NewGroupId { get; set; }
    }
}
