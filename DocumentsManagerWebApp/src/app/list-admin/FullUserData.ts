export class FullUserData {
    id:string;
    username: string;
    password: string;
    name: string;
    surname: string;
    email: string;
    
    constructor(aId:string,aUsername:string,aPassword:string, aName:string, aSurname:string, aEmail:string){
      this.id = aId;
      this.username = aUsername;
      this.password = aPassword;
      this.name = aName;
      this.surname = aSurname;
      this.email = aEmail;
    }
  }
 