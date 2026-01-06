import * as yup from 'yup';

const fileUploadRequestSchema = yup.object({
    name: yup.string()
        .required("Image Name cannot be empty!")
        .max(150, "Image Name must be at most 150 characters long!"),
    extension: yup.string()
        .required("Image Extension cannot be empty!")
        .max(5, "Image Extension must be at most 5 characters long!"),
    data: yup.string()
        .required("Image Data cannot be empty!")
});

export default fileUploadRequestSchema;