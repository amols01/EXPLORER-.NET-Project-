package com.explorer.Utils;

import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.DeserializationContext;
import com.fasterxml.jackson.databind.JsonDeserializer;
import com.fasterxml.jackson.databind.JsonNode;
import com.explorer.Models.MRoles;
import com.explorer.Repositories.RoleRepository;
import org.springframework.beans.factory.annotation.Autowired;

import java.io.IOException;

public class CustomRoleDeserializer extends JsonDeserializer<MRoles> {

    @Autowired
    private RoleRepository roleRepository;

    @Override
    public MRoles deserialize(JsonParser jsonParser, DeserializationContext ctxt) throws IOException, JsonProcessingException {
        JsonNode node = jsonParser.getCodec().readTree(jsonParser);
        int roleId = node.asInt();
        
        return roleRepository.findById(roleId)
                .orElseThrow(() -> new RuntimeException("Role not found"));
    }
}
