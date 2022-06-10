export interface IRegisterRequest {
    email: string;
    username: string;
    password: string;
    confirmPassword: string;
}

export interface ILoginRequest {
    email: string;
    password: string;
    rememberMe: boolean;
}