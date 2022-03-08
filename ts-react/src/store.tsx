import { configureStore } from "@reduxjs/toolkit";
import { userSlice } from "./models/userSlice";
// ...

export const store = configureStore({
  reducer: {
    userState: userSlice.reducer,
  },
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Infer the `AppDispatch` type from the store itself
export type AppDispatch = typeof store.dispatch;
