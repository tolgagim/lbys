export class CustomerDto {
    id: string;  // Guid türü JavaScript'te string olarak temsil edilir
    name: string;
    code?: string;
    taxNumber?: string;
    taxOffice?: string;
    status:boolean;
    entCode?:string;

    constructor(id: string, name: string, code?: string, taxNumber?: string, taxOffice?: string, status?:boolean,entCode?:string) {
        this.id = id;
        this.name = name;
        this.code = code;
        this.taxNumber = taxNumber;
        this.taxOffice = taxOffice;
        this.status=status;
        this.entCode;
    }
}
