import { useEffect, useState } from "react";
import { createEvent, fetchEvents } from "../services/event";
import EventCard from "./Event";
import CreateEventForm from "./CreateEventForm";

function EventSection() {
  const [events, setEvents] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const response = await fetchEvents();
      if (response && response.items) {
        setEvents(response.items);
      } else {
        console.error("Invalid data format", response);
      }
    };
    fetchData();
  }, []);

  const onCreate = async (event) => {
    await createEvent(event);
    var events = await fetchEvents();
    setEvents(events.items);
  };

  return (
    <section className="p-8 flex flex-row justify-start items-start gap-12">
      <div className="flex flex-col w-1/3 gap-10">
        <CreateEventForm onCreate={onCreate}></CreateEventForm>
      </div>
      <ul className="flex flex-col gap-5 flex-1">
        {events.map((e) => (
          <li key={e.id}>
            <EventCard
              name={e.name}
              description={e.description}
              place={e.place}
              time={e.time}
              category={e.category}
              maxParticipantCount={e.maxParticipantCount}
              image={e.image}
            ></EventCard>
          </li>
        ))}
      </ul>
    </section>
  );
}

export default EventSection;
