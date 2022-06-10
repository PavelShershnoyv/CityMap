import useCookie from 'react-use-cookie';

const useAuth = () => {
    const [isAuthenticated] = useCookie('Auth');
    return isAuthenticated;
}

export default useAuth;