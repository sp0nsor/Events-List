import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import EventSection from "./components/EventSection";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<EventSection />} />
      </Routes>
    </Router>
  );
}

export default App;
