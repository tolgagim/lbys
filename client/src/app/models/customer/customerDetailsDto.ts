export interface CustomerDetailsDto {
    id: string;
    name: string;
    description?: string;
    code?: string;
    taxNumber?: string;
    taxOffice?: string;
    address?: string;
    phoneNumber?: string;
    mobileNumber?: string;
    entCode?:string;
}
