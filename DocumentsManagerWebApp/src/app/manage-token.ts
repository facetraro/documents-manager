export class ManageToken {
    private tokenNameStorage : string = "DocumentsManagerSession";    
    saveToken(token:string):void{
        localStorage.setItem(this.tokenNameStorage, token);
    }
    getToken():string{
        return localStorage.getItem(this.tokenNameStorage);
    }
}