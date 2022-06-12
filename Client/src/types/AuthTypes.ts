export interface IRegisterRequest {
    email: string;
    firstName: string;
    password: string;
    confirmPassword: string;
    rememberMe: boolean;
}

export interface ILoginRequest {
    email: string;
    password: string;
    rememberMe: boolean;
}