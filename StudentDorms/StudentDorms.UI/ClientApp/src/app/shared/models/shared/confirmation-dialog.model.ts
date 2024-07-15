export class ConfirmationDialogModel {
    Header: string;
    Message: string;
  
    constructor(header: string, message: string) {
      this.Header = header;
      this.Message = message;
    }
  }
  
  export class ConfirmationWfDialogModel {
    Header: string;
    Message: string;
    RequireComment: boolean;
    AllowComment: boolean;
  
    constructor(header: string, message: string, requireComment: boolean, allowComment: boolean) {
        this.Header = header;
        this.Message = message;
        this.RequireComment = requireComment;
        this.AllowComment = allowComment;
    }
  }