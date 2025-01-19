import {
  Input,
  Textarea,
  Button,
  FormControl,
  FormLabel,
  Box,
} from "@chakra-ui/react";
import { useState } from "react";

export default function CreateEventForm({ onCreate }) {
  const [event, setEvent] = useState({
    name: "",
    description: "",
    place: "",
    category: "",
    maxParticipantCount: "",
    date: "",
    image: null,
  });

  const [error, setError] = useState("");

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    let updatedValue = value;

    if (name === "date") {
      const date = new Date(value);
      updatedValue = date.toISOString().slice(0, 16);
    }

    setEvent((prevEvent) => ({
      ...prevEvent,
      [name]: updatedValue,
    }));
  };

  const handleFileChange = (e) => {
    const { name, files } = e.target;
    setEvent((prevEvent) => ({
      ...prevEvent,
      [name]: files[0],
    }));
  };

  const onSubmit = (e) => {
    e.preventDefault();

    if (
      !event.name ||
      !event.description ||
      !event.place ||
      !event.category ||
      !event.date ||
      !event.image ||
      !event.maxParticipantCount
    ) {
      setError("Все поля должны быть заполнены.");
      return;
    }

    setError("");

    const eventWithUtcDate = {
      ...event,
      date: new Date(event.date).toISOString(),
    };

    onCreate(eventWithUtcDate);
  };

  return (
    <Box
      as="form"
      onSubmit={onSubmit}
      className="w-full flex flex-col gap-3"
      p={4}
      boxShadow="md"
    >
      <h3 className="font-bold text-xl mb-4">Создание события</h3>

      {error && (
        <Box color="red.500" mb={4}>
          {error}
        </Box>
      )}

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="name">Название</FormLabel>
        <Input
          id="name"
          name="name"
          placeholder="Введите название"
          value={event.name}
          onChange={handleInputChange}
        />
      </FormControl>

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="description">Описание</FormLabel>
        <Textarea
          id="description"
          name="description"
          placeholder="Введите описание события"
          value={event.description}
          onChange={handleInputChange}
        />
      </FormControl>

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="place">Место</FormLabel>
        <Input
          id="place"
          name="place"
          placeholder="Введите место"
          value={event.place}
          onChange={handleInputChange}
        />
      </FormControl>

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="category">Категория</FormLabel>
        <Input
          id="category"
          name="category"
          placeholder="Введите категорию"
          value={event.category}
          onChange={handleInputChange}
        />
      </FormControl>

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="maxParticipantCount">
          Максимальное количество участников
        </FormLabel>
        <Input
          id="maxParticipantCount"
          name="maxParticipantCount"
          type="number"
          value={event.maxParticipantCount}
          onChange={handleInputChange}
        />
      </FormControl>

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="date">Дата</FormLabel>
        <Input
          id="date"
          name="date"
          type="datetime-local"
          value={event.date}
          onChange={handleInputChange}
        />
      </FormControl>

      <FormControl mb={4} isRequired>
        <FormLabel htmlFor="image">Изображение</FormLabel>
        <Input
          id="image"
          name="image"
          type="file"
          onChange={handleFileChange}
        />
      </FormControl>

      <Button type="submit" colorScheme="teal">
        Создать событие
      </Button>
    </Box>
  );
}
