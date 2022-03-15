import { createSlice, PayloadAction } from '@reduxjs/toolkit'
import type { RootState } from '../store/store'
import IUser from './IUser'

// Define a type for the slice state
interface UserState {
  user: IUser
}

// Define the initial state using that type
const initialState: UserState = {
    user: {name: '', loggedIn: false}
}

// login should be a thunk
export const userSlice = createSlice({
  name: 'user',
  // `createSlice` will infer the state type from the `initialState` argument
  initialState,
  reducers: {
    login: (state, action: PayloadAction<IUser>) => {
      state.user = action.payload;
    },
    logout: state => {
      state.user = {name: '', loggedIn: false}
    } 
  }
})

export const { login, logout } = userSlice.actions

// Other code such as selectors can use the imported `RootState` type
export const selectUser = (state: RootState) => state.userState

export default userSlice.reducer