export class TokenResponse {
  constructor(
    public token: string,
    public refreshToken: string,
    public refreshTokenExpiryTime: Date
  ) {}
}