export class ManageToken {
    private tokenNameStorage : string = "DocumentsManagerSession";    
    private RoleNameStorage : string = "DocumentsManagerRole";  
    saveToken(token:string):void{
        localStorage.setItem(this.tokenNameStorage, token);
    }
    getToken():string{
        return localStorage.getItem(this.tokenNameStorage);
    }
    saveRole(token:string):void{
        localStorage.setItem(this.RoleNameStorage, token);
    }
    getRole():string{
        return localStorage.getItem(this.RoleNameStorage);
    }
}