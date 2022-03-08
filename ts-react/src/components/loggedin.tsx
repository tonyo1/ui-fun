
import { useAppSelector, useAppDispatch } from '../hooks'
import IUser from '../models/IUser'

import { login, logout } from '../models/userSlice'


const LoggedIn = () => {
    // REDUX State
    const user: IUser = useAppSelector(state => state.userState.user)
    const dispatch = useAppDispatch()

    console.log('user = ', user);

    function handleClick() {
        if (user.loggedIn) {
            dispatch(logout())
        }
        else {
            dispatch(login({ name: 'test', loggedIn: true }))
        }
    }

    return (
        <>
            <div className="navbar-nav ms-auto">
                <a title='login'
                    onClick={() => handleClick()}
                    href="#"
                    className="nav-item nav-link">
                    Login !{user.name}!
                </a>
            </div>
        </>
    );
}
export default LoggedIn;