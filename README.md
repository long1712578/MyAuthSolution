1. OAuth2 Client Credential flow giữa client và server
2. Cấu hình API scope , clients trong IdentityServer (file Config.cs)
3. Xác thực acess token trong API bằng AddJWtBearer()
4. Github actions:
	- Tự động build mỗi lần push
	- Kiểm tra thành công của các project.
5. Giải thích "Key tạm thời"
	- Khi dùng AddDeveloperSigningCredential().
		+ Tự tạo một cặp khóa RSA(private + public key).
		+ Lưu trữ nó ở file .json trong thư mục keys hoặc trong root.
		+ Dùng private key để ký token jwt.
		+ API dùng public key từ Discovery Endpoint (./well-known/openid-configuration/jwks) để kiểm tra chữ ký.
	=> is-signing-key...json: Đây là private key được IdentityServer sinh ra để ký token.
	=> tempkey.jwk: Có thể là phiên bản JWK (Json Web Key) của key đó (Không quan trọng trong dev)
