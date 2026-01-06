import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  constructor() { }

  parseImageData(dataString: string) {
    const match = dataString.match(/data:([a-zA-Z0-9]+\/[a-zA-Z0-9-.+]+).*,.*/);
    if (match && match.length > 1) {
      const mimeType = match[1];
      const extension = mimeType.split('/')[1];

      const fileUploadRequest = {
        name: `file.${extension}`,
        extension: extension,
        data: dataString
      };

      return fileUploadRequest;
    } else {
      throw new Error('Invalid or unsupported data string');
    }
  }
}
