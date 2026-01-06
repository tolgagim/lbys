import { FileUploadRequest } from "../fileUploadRequest";

export interface UpdateUserRequest {
    id: string;
    firstName?: string;
    lastName?: string;
    phoneNumber?: string;
    email?: string;
    image?: FileUploadRequest;
    deleteCurrentImage: boolean;
    birthDate?:Date;
    entCode?:string;
}

